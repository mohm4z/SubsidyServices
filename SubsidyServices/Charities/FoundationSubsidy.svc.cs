using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.HandleFault;
using Models.Charities;
using DAL.Charities;
using DAL.DbManager;

namespace SubsidyServices.Charities
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FoundationSubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FoundationSubsidy.svc or FoundationSubsidy.svc.cs at the Solution Explorer and start debugging.
    public class FoundationSubsidy : IFoundationSubsidy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="P_REG_ID"></param>
        /// <returns></returns>
        public CharityInfo GetCharityInfo(
            long LicenseNumber,
            int CharityType
            )
        {
            try
            {
                /// Data Validations

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.GetCharityInfoDAL(
                        LicenseNumber,
                        CharityType
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
