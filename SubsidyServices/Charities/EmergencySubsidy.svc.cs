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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmergencySubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmergencySubsidy.svc or EmergencySubsidy.svc.cs at the Solution Explorer and start debugging.
    public class EmergencySubsidy : IEmergencySubsidy
    {
        public RequestResult InsertEmergencySubsidy(
              EmergencyInfo cnst,
              List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (cnst.CheckedData.AgencyType == 0 ||
                    cnst.CheckedData.AgencyLicenseNumber == 0 ||
                    String.IsNullOrEmpty(cnst.CheckedData.CommissionerNumber) ||
                    cnst.CharityMainData.SubsidyType == 0 ||
                    cnst.CharityMainData.BeneficiariesCount == 0 ||
                    cnst.CharityMainData.VolunteersCount == 0 ||
                    cnst.CharityMainData.SaudiEmployeesCount == 0 ||
                    cnst.CharityMainData.NonSaudiEmployeesCount == 0 ||
                    cnst.CharityMainData.IsbudgetIssued == 0 ||
                    cnst.CharityMainData.IsBoardOfDirectorsMeetingsRegular == 0 ||
                    cnst.CharityMainData.IsGeneralAssemblyMeetingsRegular == 0 ||
                    String.IsNullOrEmpty(cnst.CharityMainData.GeneralAssemblyIrregularityMeetingReason) ||
                    cnst.CharityMainData.TotalExpensesAdministrativePreviousYear == 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());

                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertEmergencySubsidyDAL(
                        cnst,
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
