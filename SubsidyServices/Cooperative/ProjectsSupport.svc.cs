using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProjectsSupport" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProjectsSupport.svc or ProjectsSupport.svc.cs at the Solution Explorer and start debugging.
    public class ProjectsSupport : IProjectsSupport
    {
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
                if (String.IsNullOrEmpty(ProjectInfo.ManagersInfo.ChairmanBoardName))
                    throw new FaultException<ValidationFault>(new ValidationFault());

                using (CooperativeDAL dal = new CooperativeDAL(new ADO()))
                {
                    return dal.InsertProjectsSupportDAL(
                        ProjectInfo,
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
