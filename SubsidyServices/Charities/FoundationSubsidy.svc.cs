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
using log4net;

namespace SubsidyServices.Charities
{
    /// <summary>
    ///  خدمة الاعانة الانشائية للجمعيات الخيرية
    /// </summary>
    public class FoundationSubsidy : IFoundationSubsidy
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(FoundationSubsidy));

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

                throw new FaultException<ValidationFault>(fault, new FaultReason("General Fault"));
            }
        }
        
        public RequestResult UpdateFoundationSubsidy(
           long RequestId,
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
                    return dal.UpdateFoundationSubsidyDAL(
                        RequestId,
                        CheckedData,
                        ChairmanBoardMobileNumber,
                        ChairmanBoardName);
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

                throw new FaultException<ValidationFault>(fault, new FaultReason("General Fault"));
            }
        }
    }
}
