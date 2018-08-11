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
            ProjectInfo prj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = prj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = prj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = prj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = prj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = prj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = prj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "ECONOMIC_FEASIBILITY_FLG" , VALUE = prj.IsThereFeasibilityStudy},
                new SpInPuts(){KEY = "PROJ_TYPE" , VALUE = prj.ProjectType},
                new SpInPuts(){KEY = "PROJ_DESC" , VALUE = prj.ProjectDescription},
                new SpInPuts(){KEY = "PROJ_LOCATION" , VALUE = prj.ProjectLocation},
                new SpInPuts(){KEY = "PROJ_EXEC_REGION" , VALUE = prj.ExecutingAgency},
                new SpInPuts(){KEY = "PROJ_AGREE_FLG" , VALUE = prj.IsThereImplementProjectAgreement},
                new SpInPuts(){KEY = "PROJ_ACTUAL_COST" , VALUE = prj.ActualCost},
                new SpInPuts(){KEY = "PROJ_STAGES_FUND" , VALUE = prj.DistributeAmountsOnStages},
                new SpInPuts(){KEY = "PROJ_EXPNS_CMBTL_FLG" , VALUE = prj.IsExpendedIdenticalBudget},
                new SpInPuts(){KEY = "PROJ_REG_SHARE_AMNT" , VALUE = prj.AmountForProject},
                new SpInPuts(){KEY = "PROJ_EXPEND_BAL_AMNT" , VALUE = prj.AmountExpendedOnBudget},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = prj.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_PROJECTS",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    prj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertInsertOperationMechanismsDAL(
            OperationInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_HAVE_3_MACHINES_FLG" , VALUE = obj.IsAgencyHaveThreeMachinesReady},
                new SpInPuts(){KEY = "P_MACHINES_WORKERS_FLG" , VALUE = obj.WorkersOnMachines},
                new SpInPuts(){KEY = "P_SAUDI_WORKERS_SALARIES" , VALUE = obj.SaudisSalaries},
                new SpInPuts(){KEY = "P_SAUDI_WORKERS_COUNT" , VALUE = obj.SaudisCount},
                new SpInPuts(){KEY = "P_NON_SAUDI_WORKERS_SALARIES" , VALUE = obj.NonSaudisSalaries},
                new SpInPuts(){KEY = "P_NON_SAUDI_WORKERS_COUNT" , VALUE = obj.NonSaudisCount},
                new SpInPuts(){KEY = "P_MACHINES_COUNT" , VALUE = obj.OwnedVehiclesCount},
                new SpInPuts(){KEY = "P_JOB_CONTRACT_CMTBL_FLG" , VALUE = obj.IsJobCompatibleWithContract},
                new SpInPuts(){KEY = "P_BOD_MACHINES_CERTF_FLG" , VALUE = obj.IsThereJobCertificateForMachines},
                new SpInPuts(){KEY = "P_SUPPLIER_MACHINES_CERTF_FLG" , VALUE = obj.AmountForProject},
                new SpInPuts(){KEY = "P_REQUEST_AMOUNT" , VALUE = obj.RequiredSubsidy},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = obj.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_BOD_REWARD",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    obj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertFoundationCooperativeDAL(
            FoundationInfo FoundationInfo,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = FoundationInfo.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = FoundationInfo.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = FoundationInfo.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = FoundationInfo.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = FoundationInfo.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = FoundationInfo.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_ESTBLSH_CAPITAL" , VALUE = FoundationInfo.CompanyCapitalInBeginning},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = FoundationInfo.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_ESTBLSH",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    FoundationInfo.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertBoardDirectorsRemunerationDAL(
            BoardDirectorsRemunerationInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = obj.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = obj.IsBudgetRegular},
                new SpInPuts(){KEY = "P_PROFIT_FLG" , VALUE = obj.IsAssociationMadeProfitsInlastbudget},
                new SpInPuts(){KEY = "P_PROFIT_AFTER_ZAKAT_AMNT" , VALUE = obj.ProfitsAfterZakat},
                new SpInPuts(){KEY = "P_REQUEST_AMOUNT" , VALUE = obj.RequiredSubsidy},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = obj.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_BOD_REWARD",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    obj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertReassigningManagerDAL(
            ManagerInfo mgInf,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = mgInf.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = mgInf.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = mgInf.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = mgInf.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = mgInf.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = mgInf.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = mgInf.DirectorsBoardMeetings},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = mgInf.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = mgInf.IsBudgetRegular},
                new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = mgInf.CooEmployeeInfo.EmployeeName},
                new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = mgInf.CooEmployeeInfo.EmployeeNationalId},
                new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = mgInf.CooEmployeeInfo.EmployeeBirthDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = mgInf.CooEmployeeInfo.EmployeeHireDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = mgInf.CooEmployeeInfo.EmployeeQualification},
                new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = mgInf.CooEmployeeInfo.EmployeeSpecialistCD},
                new SpInPuts(){KEY = "P_SBSD_EMP_YEAR_SALARY_CS" , VALUE = mgInf.SalaryForWhichYear},
                new SpInPuts(){KEY = "P_SBSD_EMP_CONTRACT_FLG" , VALUE = mgInf.CooEmployeeInfo.IsThereJobContract},
                new SpInPuts(){KEY = "P_SBSD_EMP_FULLTIME_FLG" , VALUE = mgInf.IsDirectorDedicatedForJob},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_BOD_AGREE_FLG" , VALUE = mgInf.CooEmployeeInfo.AppointmentBoardApproval},
                new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = mgInf.AnnualSalary},
                new SpInPuts(){KEY = "P_SBSD_EMP_PRIVILEGES" , VALUE = mgInf.CooEmployeeInfo.OtherPrivileges},
                new SpInPuts(){KEY = "P_REQUEST_AMOUNT" , VALUE = mgInf.RequiredSubsidy},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = mgInf.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_MANAGER",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    mgInf.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertReassigningAccountantDAL(
            AccountantInfo mgInf,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = mgInf.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = mgInf.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = mgInf.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = mgInf.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = mgInf.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = mgInf.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = mgInf.CooEmployeeInfo.EmployeeName},
                new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = mgInf.CooEmployeeInfo.EmployeeBirthDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = mgInf.CooEmployeeInfo.EmployeeNationalId},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = mgInf.CooEmployeeInfo.EmployeeHireDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = mgInf.CooEmployeeInfo.EmployeeSpecialistCD},
                new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = mgInf.CooEmployeeInfo.EmployeeQualification},
                new SpInPuts(){KEY = "P_BALSHT_SAL_SPRT_FLG" , VALUE = mgInf.AccountantSalarySeparateInTheBudget},
                new SpInPuts(){KEY = "P_SBSD_EMP_CONTRACT_FLG" , VALUE = mgInf.IsContractSignedbotheAndNameAndSalaryShown},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_BOD_AGREE_FLG" , VALUE = mgInf.CooEmployeeInfo.AppointmentBoardApproval},
                new SpInPuts(){KEY = "P_SPONSOR_FLG" , VALUE = mgInf.IsNonSaudiSponsorshipOnAgancy},
                new SpInPuts(){KEY = "P_PAYROLL_FLG" , VALUE = mgInf.IsAccountantReceiptSheetAvailable},
                new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = mgInf.AnnualSalary},
                new SpInPuts(){KEY = "P_SBSD_EMP_PRIVILEGES" , VALUE = mgInf.CooEmployeeInfo.OtherPrivileges},
                new SpInPuts(){KEY = "P_REQUEST_AMOUNT" , VALUE = mgInf.RequiredSubsidy},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = mgInf.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "CS_P_SUBSIDY_ACCOUNTANT",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    mgInf.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
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

            RequestResult RequestResult = new RequestResult
            {
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            return RequestResult;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
