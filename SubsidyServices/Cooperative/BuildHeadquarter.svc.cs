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
    /// خدمة اعانة بناء مقر للجمعات التعاونية 
    /// </summary>
    public class BuildHeadquarter : IBuildHeadquarter
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="HeadquarterInfo"></param>
       /// <param name="Files"></param>
       /// <returns></returns>
        public RequestResult InsertBuildHeadquarter(
            HeadquarterInfo HeadquarterInfo,
            List<StagesInfo> StagesInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(HeadquarterInfo) ||
                    DataValidation.IsEmptyOrDefault(HeadquarterInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefault(HeadquarterInfo.ManagersInfo) ||
                    DataValidation.IsEmptyOrDefaultList(StagesInfo) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertBuildHeadquartertDAL(
                        HeadquarterInfo,
                        StagesInfo,
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
