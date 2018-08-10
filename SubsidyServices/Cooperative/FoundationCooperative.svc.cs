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

namespace SubsidyServices.Cooperative
{
    /// <summary>
    /// خدمة اعانة تأسيسية للجمعيات التعاونية
    /// </summary>
    public class FoundationCooperative : IFoundationCooperative
    {
        
        public RequestResult InsertFoundationCooperative(
            FoundationInfo FoundationInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(FoundationInfo) ||
                    DataValidation.IsEmptyOrDefault(FoundationInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(FoundationInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertFoundationCooperativeDAL(
                        FoundationInfo,
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
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(fault);
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
    }
}
