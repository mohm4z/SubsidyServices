using System;
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
    /// خدمة موظفي الجمعيات الخيرية
    /// </summary>
    [ServiceBehavior(ConfigurationName = "mlsd.ServicesBehavior")]
    public class EmployeeSubsidy : IEmployeeSubsidy
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(EmployeeSubsidy));

        public RequestResult InsertEmployeeSubsidy(
            EmployeeInfo EmployeeInfo,
            List<Files> Files
            )
        {
            try
            {
                /// Data Validations
                if (DataValidation.IsEmptyOrDefault(EmployeeInfo) ||
                    DataValidation.IsEmptyOrDefault(EmployeeInfo.CheckedData) ||
                    DataValidation.IsEmptyOrDefaultList(Files))
                    throw new FaultException<ValidationFault>(new ValidationFault());


                /// Call Database
                using (CharityDAL dal = new CharityDAL(new ADO()))
                {
                    return dal.InsertEmployeeSubsidyDAL(
                        EmployeeInfo,
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

                var flex = new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameters is Required but have null or empty or 0 value"));

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
