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

namespace SubsidyServices.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommonServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CommonServices.svc or CommonServices.svc.cs at the Solution Explorer and start debugging.

    public class CommonServices : ICommonServices
    {
        public IEnumerable<LookupTable> GetLookup(
            string ApplicationCode,
            int TabNumber
            )
        {
            try
            {
                /// Data Validations
                if (String.IsNullOrEmpty(ApplicationCode))
                    throw new FaultException<ValidationFault>(new ValidationFault());

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

                throw new FaultException<ValidationFault>(
                    fault);
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        public AgencyInfo GetAgencyInfo(
            int AgencyType,
            long AgencyLicenseNumber
            )
        {
            try
            {
                /// Data Validations

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyInfoDAL(
                        AgencyType,
                        AgencyLicenseNumber
                        );
                }
            }
            catch (FaultException<ValidationFault> )
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(
                    fault);
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message + " StackTrace: " + ex.StackTrace,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        public AgencyGoals GetAgencyGoals(
            int AgencyType,
            long AgencyLicenseNumber
            )
        {
            try
            {
                /// Data Validations

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyGoalsDAL(
                        AgencyType,
                        AgencyLicenseNumber
                        );
                }
            }
            catch (FaultException<ValidationFault> )
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(
                    fault);
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }

        /// <summary>
        /// 
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

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (CommonDAL dal = new CommonDAL(new ADO()))
                {
                    return dal.GetAgencyFilesDAL(
                        SubsidyCode
                        );
                }
            }
            //catch (FaultException<ValidationFault> e)
            //{
            //    ValidationFault fault = new ValidationFault
            //    {
            //        Result = true,
            //        Message = "Parameter not correct",
            //        Description = "Invalid Parameter Name or All Parameters are nullu"
            //    };

            //    throw new FaultException<ValidationFault>(
            //        fault);
            //}
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }

    }
}
