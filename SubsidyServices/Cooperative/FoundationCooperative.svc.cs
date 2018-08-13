using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;
using DAL.DbManager;
using Models.HandleFault;
using DAL.Cooperative;
using Models.Cooperative;
using log4net;

namespace SubsidyServices.Cooperative
{
    /// <summary>
    /// خدمة اعانة تأسيسية للجمعيات التعاونية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class FoundationCooperative : IFoundationCooperative
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(FoundationCooperative));

        public RequestResult InsertFoundationCooperative(
            FoundationInfo FoundationInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(FoundationInfo) ||
                    DataValidation.IsEmptyOrDefault(FoundationInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(FoundationInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertFoundationCooperativeDAL(
                        FoundationInfo,
                        Files
                        );
                }
            }
            catch (FaultException<ValidationFault>)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameters is Required but have null or empty or 0 value"
                };

                var flex = new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameters is Required but have null or empty or 0 value"));

                _log.Error(flex);

                throw flex;
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                _log.Error(ex);

                throw new FaultException<ValidationFault>(fault);
            }
        }
    }
}
