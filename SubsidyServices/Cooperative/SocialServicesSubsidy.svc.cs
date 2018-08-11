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
    /// خدمة اعانة خدمات اجتماعية للجمعيات التعاونية 
    /// </summary>
    public class SocialServicesSubsidy : ISocialServicesSubsidy
    {
        
        public RequestResult InsertSocialServicesSubsidy(
            SocialServiceInfo SocialServiceInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(SocialServiceInfo) ||
                    DataValidation.IsEmptyOrDefault(SocialServiceInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(SocialServiceInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefault(SocialServiceInfo.MeetingInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertSocialServicesSubsidyDAL(
                        SocialServiceInfo,
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
