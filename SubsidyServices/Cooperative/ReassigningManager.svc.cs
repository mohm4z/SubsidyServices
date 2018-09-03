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
using log4net;

namespace SubsidyServices.Cooperative
{
    /// <summary>
    /// خدمة اعانة تعيين مدير جمعية تعاونية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class ReassigningManager : IReassigningManager
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ReassigningManager));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertReassigningManager(
            ManagerInfo ManagerInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(ManagerInfo);
                DataValidation.IsEmptyOrDefault2(ManagerInfo.CheckedData);
                DataValidation.IsEmptyOrDefault2(ManagerInfo.ManagersInfo);
                DataValidation.IsEmptyOrDefault2(ManagerInfo.CooEmployeeInfo);
                DataValidation.IsEmptyOrDefault2(ManagerInfo.MeetingInfo);
                DataValidation.IsEmptyOrDefaultList2(Files);

                //if (DataValidation.IsEmptyOrDefault(ManagerInfo) ||
                //    DataValidation.IsEmptyOrDefault(ManagerInfo.CheckedData) ||
                //    DataValidation.IsEmptyOrDefault(ManagerInfo.ManagersInfo) ||
                //    DataValidation.IsEmptyOrDefault(ManagerInfo.CooEmployeeInfo) ||
                //    DataValidation.IsEmptyOrDefault(ManagerInfo.MeetingInfo) ||
                //    DataValidation.IsEmptyOrDefaultList(Files))
                //    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertReassigningManagerDAL(
                        ManagerInfo,
                        Files
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
