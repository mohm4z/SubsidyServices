using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.HandleFault;
using DAL.Charities;
using DAL.DbManager;
using Models.Common;
using System.Reflection;

namespace SubsidyServices.Charities
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FoundationSubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FoundationSubsidy.svc or FoundationSubsidy.svc.cs at the Solution Explorer and start debugging.
    public class FoundationSubsidy : IFoundationSubsidy
    {
        public RequestResult InsertFoundationSubsidy(
            CheckedData CheckedData,
            string ChairmanBoardMobileNumber,
            string ChairmanBoardName
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(CheckedData) ||
                    String.IsNullOrEmpty(ChairmanBoardMobileNumber) ||
                    String.IsNullOrEmpty(ChairmanBoardName))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertFoundationSubsidyDAL(
                        CheckedData,
                        ChairmanBoardMobileNumber,
                        ChairmanBoardName);
                }
            }
            catch (FaultException<ValidationFault> )
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameters is Required but have null or empty or 0 value"
                };

                throw new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameters is Required but have null or empty or 0 value"));
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault, new FaultReason("General Fault"));
            }
        }



    }
}
