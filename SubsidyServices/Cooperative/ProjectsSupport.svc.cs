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
    /// خدمة اعانة المشاريع للجمعيات التعاونية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class ProjectsSupport : IProjectsSupport
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ProjectsSupport));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertProjectsSupport(
            ProjectInfo ProjectInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(ProjectInfo);
                DataValidation.IsEmptyOrDefault2(ProjectInfo.CheckedData);
                DataValidation.IsEmptyOrDefault2(ProjectInfo.ManagersInfo);
                DataValidation.IsEmptyOrDefaultList2(Files);

                //if (DataValidation.IsEmptyOrDefault(ProjectInfo) ||
                //    DataValidation.IsEmptyOrDefault(ProjectInfo.CheckedData) ||
                //    DataValidation.IsEmptyOrDefault(ProjectInfo.ManagersInfo) ||
                //    DataValidation.IsEmptyOrDefaultList(Files))
                //    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertProjectsSupportDAL(
                        ProjectInfo,
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
