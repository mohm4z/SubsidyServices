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
    /// خدمة اعانة دعم تأسيسية ودعم إضافي للجان التنمية 
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class FoundationAdditionalSubsidyCommittees : IFoundationAdditionalSubsidyCommittees
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(FoundationAdditionalSubsidyCommittees));

        public RequestResult InsertFoundationAdditionalSubsidyCommittees(
           CommitteeRequestInfo CommitteeRequestInfo
           )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(CommitteeRequestInfo);
                DataValidation.IsEmptyOrDefault2(CommitteeRequestInfo.CheckedData);
                DataValidation.IsEmptyOrDefaultList2(CommitteeRequestInfo.Projects);

                    //if (DataValidation.IsEmptyOrDefault(CommitteeRequestInfo) ||
                    //    DataValidation.IsEmptyOrDefault(CommitteeRequestInfo.CheckedData) ||
                    //    DataValidation.IsEmptyOrDefaultList(CommitteeRequestInfo.Projects))
                    //    throw new FaultException<ValidationFault>(new ValidationFault());


                    /// Call Database
                    using (CommitteesDAL dal = new CommitteesDAL(new ADO()))
                {
                    return dal.InsertFoundationAdditionalSubsidyCommitteesDAL(
                        CommitteeRequestInfo
                        );
                }
            }
            catch (FaultException<ValidationFault> flex)
            {
                //ValidationFault fault = new ValidationFault
                //{
                //    Result = true,
                //    Message = "Parameter not correct",
                //    Description = "Invalid Parameters is Required but have null or empty or 0 value"
                //};

                //var flex = new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameters is Required but have null or empty or 0 value"));

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
