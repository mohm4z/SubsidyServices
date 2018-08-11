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
    /// <summary>
    /// خدمة اعانة تعيين محاسب جمعية تعاونية
    /// </summary>
    public class ReassigningAccountant : IReassigningAccountant
    {

       /// <summary>
       /// 
       /// </summary>
       /// <param name="AccountantInfo"></param>
       /// <param name="Files"></param>
       /// <returns></returns>
        public RequestResult InsertReassigningAccountant(
            AccountantInfo AccountantInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(AccountantInfo) ||
                    DataValidation.IsEmptyOrDefault(AccountantInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(AccountantInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefault(AccountantInfo.CooEmployeeInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertReassigningAccountantDAL(
                        AccountantInfo,
                        Files
                        );
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
                    Message = ex.Message ,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }
    }
}
