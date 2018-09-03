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
    /// خدمة اعانة خسائر و مخاطر للجمعيات التعاونية 
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class LossSubsidy : ILossSubsidy
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LossSubsidy));

        public RequestResult InsertLossSubsidy(
            LossInfo LossInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(LossInfo);
                DataValidation.IsEmptyOrDefault2(LossInfo.CheckedData);
                DataValidation.IsEmptyOrDefault2(LossInfo.ManagersInfo);
                DataValidation.IsEmptyOrDefault2(LossInfo.MeetingInfo);
                DataValidation.IsEmptyOrDefaultList2(Files);

                //if (DataValidation.IsEmptyOrDefault(LossInfo) ||
                //    DataValidation.IsEmptyOrDefault(LossInfo.CheckedData) ||
                //    DataValidation.IsEmptyOrDefault(LossInfo.ManagersInfo) ||
                //    DataValidation.IsEmptyOrDefault(LossInfo.MeetingInfo) ||
                //    DataValidation.IsEmptyOrDefaultList(Files))
                //    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertLossSubsidyDAL(
                        LossInfo,
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
