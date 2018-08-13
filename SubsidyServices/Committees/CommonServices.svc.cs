using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.HandleFault;
using DAL.DbManager;
using log4net;
using Models.Committees;
using DAL.Committees;
using Models.Common;

namespace SubsidyServices.Committees
{
    /// <summary>
    /// خدمات مشتركة للجان التنمية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class CommonServices : ICommonServices
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CommonServices));

        /// <summary>
        /// بيانات لجان التنمية
        /// </summary>
        /// <param name="AgencyType"></param>
        /// <param name="AgencyLicenseNumber"></param>
        /// <returns></returns>
        public CommitteeInfo GetCommitteeInfo(
            int AgencyType,
            long AgencyLicenseNumber
            )
        {
            try
            {
                /// Data Validations
                if (AgencyType <= 0 ||
                   AgencyLicenseNumber <= 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CommitteesDAL dal = new CommitteesDAL(new ADO()))
                {
                    return dal.GetCommitteeInfoDAL(
                        AgencyType,
                        AgencyLicenseNumber
                        );
                }
            }
            catch (FaultException<ValidationFault>)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
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

        /// <summary>
        /// المبادرات
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LookupTable> GetInitiatives()
        {
            try
            {
                ///// Data Validations
                //if (String.IsNullOrEmpty(ApplicationCode) ||
                //    TabNumber <= 0 ||
                //    SubTabNumber <= 0)
                //    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CommitteesDAL dal = new CommitteesDAL(new ADO()))
                {
                    return dal.GetInitiativesDAL();
                }
            }
            //catch (FaultException<ValidationFault>)
            //{
            //    ValidationFault fault = new ValidationFault
            //    {
            //        Result = true,
            //        Message = "Parameter not correct",
            //        Description = "Invalid Parameter Name or All Parameters are nullu"
            //    };

            //    var flex = new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameters is Required but have null or empty or 0 value"));

            //    _log.Error(flex);

            //    throw flex;
            //}
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
