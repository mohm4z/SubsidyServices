using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Common;
using Models.Cooperative;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Cooperative
{
    public class CooperativeDAL : IDisposable
    {
        public readonly IADO ado;

        public CooperativeDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public RequestResult InsertProjectsSupportDAL(
             ProjectInfo emp,
             List<Files> Files
             )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                //new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emp.CheckedData.AgencyType},
                //new SpInPuts(){KEY = "P_REG_ID" , VALUE = emp.CheckedData.AgencyLicenseNumber},
                //new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = emp.SubsidyType},
                //new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = emp.ChairmanBoardName},
                //new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = emp.ChairmanBoardMobileNumber},
                //new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = emp.EmployeeName},
                //new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = emp.EmployeeHireDate},
                //new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = emp.EmployeeNationalId},
                //new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = emp.EmployeeBirthDate},
                //new SpInPuts(){KEY = "P_SBSD_EMP_NATIONALITY" , VALUE = emp.EmployeeNationality},
                //new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = emp.EmployeeQualification},
                //new SpInPuts(){KEY = "P_SBSD_EMP_SPECIALIST" , VALUE = emp.EmployeeSpecialist},
                //new SpInPuts(){KEY = "P_SBSD_EMP_SPECIALIST_CD" , VALUE = emp.EmployeeSpecialistCD},
                //new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = emp.EmployeeExpertise},
                //new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = emp.EmployeeSalary},
                //new SpInPuts(){KEY = "P_SBSD_EMP_RENT_AMOUNT" , VALUE = emp.EmployeeRentAmount},
                //new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emp.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Varchar2 , Size = 300}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
                );

            ado.ExecuteStoredProcedure(
                "CH_P_SUBSIDY_EMP",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    emp.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return chi;
        }

        public RequestResult InsertAttachmentDAL(
            long RequestId,
            int FileNumber,
            string FilePath,
            string CommissionerNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REQUEST_ID" , VALUE = RequestId},
                new SpInPuts(){KEY = "P_FILE_CODE" , VALUE = FileNumber},
                new SpInPuts(){KEY = "P_FILE_PATH" , VALUE = FilePath},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
                );

            ado.ExecuteStoredProcedure(
                "CH_P_SUBSIDY_ATTACHS",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult chi = new RequestResult
            {
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            return chi;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
