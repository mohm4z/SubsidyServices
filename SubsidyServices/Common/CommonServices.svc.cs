using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;
using DAL.Common;
using DAL.DbManager;
using Models.HandleFault;
using log4net;

namespace SubsidyServices.Common
{
    /// <summary>
    /// خدمات عامه
    /// </summary>
    public class CommonServices : ICommonServices
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CommonServices));

        /// <summary>
        /// إحضار جدول صغير
        /// </summary>
        /// <param name="ApplicationCode"></param>
        /// <param name="TabNumber"></param>
        /// <returns></returns>
        public IEnumerable<LookupTable> GetLookup(
            string ApplicationCode,
            int TabNumber
            )
        {
            try
            {
                /// Data Validations
                if (String.IsNullOrEmpty(ApplicationCode) ||
                    TabNumber <= 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetLookupDAL(
                        ApplicationCode,
                        TabNumber
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

        public IEnumerable<LookupTable> GetSubLookup(
            string ApplicationCode,
            int TabNumber,
            int SubTabNumber
            )
        {
            try
            {
                /// Data Validations
                if (String.IsNullOrEmpty(ApplicationCode) ||
                    TabNumber <= 0 ||
                    SubTabNumber <= 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetSubLookupDAL(
                        ApplicationCode,
                        TabNumber,
                        SubTabNumber
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
        /// احضار بيانات جمعيات
        /// </summary>
        /// <param name="AgencyType"></param>
        /// <param name="AgencyLicenseNumber"></param>
        /// <returns></returns>
        public AgencyInfo GetAgencyInfo(
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
                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyInfoDAL(
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
        /// احضار اهداف الجمعيات
        /// </summary>
        /// <param name="AgencyType"></param>
        /// <param name="AgencyLicenseNumber"></param>
        /// <returns></returns>
        public AgencyGoals GetAgencyGoals(
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

                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyGoalsDAL(
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
        /// احضار اسماء الملفات المطلوبة لكل خدمة
        /// </summary>
        /// <param name="SubsidyCode"></param>
        /// <returns></returns>
        public AgencyFiles GetAgencyFiles(
            long SubsidyCode
            )
        {
            try
            {
                /// Data Validations
                if (SubsidyCode <= 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());

                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyFilesDAL(
                        SubsidyCode
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

    }
}
