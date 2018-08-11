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


namespace SubsidyServices.Cooperative
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TrainingSubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TrainingSubsidy.svc or TrainingSubsidy.svc.cs at the Solution Explorer and start debugging.
    public class TrainingSubsidy : ITrainingSubsidy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertTrainingSubsidy(
            TrainingInfo TrainingInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(TrainingInfo) ||
                    DataValidation.IsEmptyOrDefault(TrainingInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(TrainingInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefault(TrainingInfo.MeetingInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertTrainingSubsidyDAL(
                        TrainingInfo,
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

                throw new FaultException<ValidationFault>(fault);
            }
        }
    }
}
