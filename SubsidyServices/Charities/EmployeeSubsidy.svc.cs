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
                if (String.IsNullOrEmpty(emp.ChairmanBoardName))
                    if (String.IsNullOrEmpty(emp.EmployeeName))
                        if (String.IsNullOrEmpty(emp.EmployeeHireDate))
                            if (String.IsNullOrEmpty(emp.EmployeeBirthDate))
                                if (String.IsNullOrEmpty(emp.EmployeeNationality))
                                    if (String.IsNullOrEmpty(emp.EmployeeNationality))
                                        if (String.IsNullOrEmpty(emp.EmployeeRentAmount))
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
