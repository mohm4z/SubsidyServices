﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using DAL.Charities;
using DAL.DbManager;
using log4net;
using Models.Charities;
using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Charities
{
    /// <summary>
    /// خدمة الاعانة الانشائية للجمعيات الخيرية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class ConstructSubsidy : IConstructSubsidy
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ConstructSubsidy));

        public RequestResult InsertConstructSubsidy(
            ConstructInfo ConstructInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                DataValidation.IsEmptyOrDefault2(ConstructInfo);
                DataValidation.IsEmptyOrDefault2(ConstructInfo.CheckedData);
                DataValidation.IsEmptyOrDefault2(ConstructInfo.CharityMainData);
                DataValidation.IsEmptyOrDefaultList2(Files);

                //if (DataValidation.IsEmptyOrDefault(ConstructInfo) ||
                //    DataValidation.IsEmptyOrDefault(ConstructInfo.CheckedData) ||
                //    DataValidation.IsEmptyOrDefault(ConstructInfo.CharityMainData) ||
                //    DataValidation.IsEmptyOrDefaultList(Files))
                //    throw new FaultException<ValidationFault>(new ValidationFault());

                /// Call Database
                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertConstructSubsidyDAL(
                        ConstructInfo,
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
