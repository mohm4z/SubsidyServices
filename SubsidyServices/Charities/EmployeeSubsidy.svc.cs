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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeSubsidy" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeSubsidy.svc or EmployeeSubsidy.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeSubsidy : IEmployeeSubsidy
    {
        public RequestResult InsertEmployeeSubsidy(
            EmployeeInfo emp,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (emp.CheckedData.AgencyType == 0 ||
                    emp.CheckedData.AgencyLicenseNumber == 0 ||
                    String.IsNullOrEmpty(emp.CheckedData.CommissionerNumber) ||
                    String.IsNullOrEmpty(emp.ChairmanBoardName) ||
                    emp.ChairmanBoardMobileNumber == 0 ||
                    String.IsNullOrEmpty(emp.EmployeeName) ||
                    String.IsNullOrEmpty(emp.EmployeeHireDate) ||
                    emp.EmployeeNationalId == 0 ||
                    String.IsNullOrEmpty(emp.EmployeeBirthDate) ||
                    String.IsNullOrEmpty(emp.EmployeeNationality) ||
                    String.IsNullOrEmpty(emp.EmployeeQualification) ||
                    String.IsNullOrEmpty(emp.EmployeeSpecialist) ||
                    String.IsNullOrEmpty(emp.EmployeeSpecialistCD) ||
                    emp.EmployeeSalary == 0 ||
                    emp.EmployeeRentAmount == 0)
                    throw new FaultException<ValidationFault>(new ValidationFault());

                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertEmployeeSubsidyDAL(
                        emp,
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
