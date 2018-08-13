using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using DAL.Committees;
using DAL.DbManager;
using log4net;
using Models.Committees;
using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Committees
{
    /// <summary>
    /// خدمة اعانة تأسيسية و سنوية و طارئة للجان التنمية 
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class CommitteeServices : ICommitteeServices
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CommitteeServices));

        public RequestResult InsertCommitteeServices(
            CommitteeRequestInfo CommitteeRequestInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(CommitteeRequestInfo) ||
                    DataValidation.IsEmptyOrDefault(CommitteeRequestInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefaultList(CommitteeRequestInfo.Projects) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CommitteesDAL dal = new CommitteesDAL(new ADO()))
                {
                    return dal.InsertCommitteeServicesDAL(
                        CommitteeRequestInfo,
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
