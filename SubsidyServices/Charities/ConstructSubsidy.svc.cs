using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using DAL.Charities;
using DAL.DbManager;
using Models.Charities;
using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Charities
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConstructSubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConstructSubsidy.svc or ConstructSubsidy.svc.cs at the Solution Explorer and start debugging.
    public class ConstructSubsidy : IConstructSubsidy
    {
        public RequestResult InsertConstructSubsidy(
              EmergencyInfo ins,
              List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (String.IsNullOrEmpty(ins.CharityMainData.GovernmentEvaluationResult))
                    if (String.IsNullOrEmpty(ins.Causes))
                        if (String.IsNullOrEmpty(ins.ActionsTaken))
                            if (String.IsNullOrEmpty(ins.CharityMainData.PartnerNames))
                                if (String.IsNullOrEmpty(ins.CharityMainData.RequiredSubsidy))
                                    throw new FaultException<ValidationFault>(new ValidationFault());


                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertConstructSubsidyDAL(
                        ins,
                        Files
                        );
                }
            }
            catch (FaultException<ValidationFault> e)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(
                    fault);
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
