﻿using System;
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
    /// خدمة اعانة تشغيل اليات للجمعات التعاونية 
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class OperationMechanisms : IOperationMechanisms
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(OperationMechanisms));

        public RequestResult InsertOperationMechanisms(
            OperationInfo OperationInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(OperationInfo);
                DataValidation.IsEmptyOrDefault2(OperationInfo.CheckedData);
                DataValidation.IsEmptyOrDefault2(OperationInfo.ManagersInfo);
                DataValidation.IsEmptyOrDefaultList2(Files);

                //if (DataValidation.IsEmptyOrDefault(OperationInfo) ||
                //    DataValidation.IsEmptyOrDefault(OperationInfo.CheckedData) ||
                //    DataValidation.IsEmptyOrDefault(OperationInfo.ManagersInfo) ||
                //    DataValidation.IsEmptyOrDefaultList(Files))
                //    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertOperationMechanismsDAL(
                        OperationInfo,
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
