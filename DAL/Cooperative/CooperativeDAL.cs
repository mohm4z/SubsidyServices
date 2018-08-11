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
            ProjectInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "ECONOMIC_FEASIBILITY_FLG" , VALUE = obj.IsThereFeasibilityStudy},
                new SpInPuts(){KEY = "PROJ_TYPE" , VALUE = obj.ProjectType},
                new SpInPuts(){KEY = "PROJ_DESC" , VALUE = obj.ProjectDescription},
                new SpInPuts(){KEY = "PROJ_LOCATION" , VALUE = obj.ProjectLocation},
                new SpInPuts(){KEY = "PROJ_EXEC_REGION" , VALUE = obj.ExecutingAgency},
                new SpInPuts(){KEY = "PROJ_AGREE_FLG" , VALUE = obj.IsThereImplementProjectAgreement},
                new SpInPuts(){KEY = "PROJ_ACTUAL_COST" , VALUE = obj.ActualCost},
                new SpInPuts(){KEY = "PROJ_STAGES_FUND" , VALUE = obj.DistributeAmountsOnStages},
                new SpInPuts(){KEY = "PROJ_EXPNS_CMBTL_FLG" , VALUE = obj.IsExpendedIdenticalBudget},
                new SpInPuts(){KEY = "PROJ_REG_SHARE_AMNT" , VALUE = obj.AmountForProject},
                new SpInPuts(){KEY = "PROJ_EXPEND_BAL_AMNT" , VALUE = obj.AmountExpendedOnBudget},
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
                    obj.CheckedData.CommissionerNumber.ToString()
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
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_HAVE_3_MACHINES_FLG" , VALUE = obj.IsAgencyHaveThreeMachinesReady},
                new SpInPuts(){KEY = "P_MACHINES_WORKERS_FLG" , VALUE = obj.WorkersOnMachines},
                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = obj.WorkersOnMachines},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = obj.IsBoredMeetingsRegular},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = obj.IsGeneralAssemblyeetingsRegular},
                new SpInPuts(){KEY = "P_SAUDI_WORKERS_SALARIES" , VALUE = obj.IsBudgetRegular},
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
                "CS_P_SUBSIDY_MACHINES",
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
            FoundationInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_ESTBLSH_CAPITAL" , VALUE = obj.CompanyCapitalInBeginning},
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
                    obj.CheckedData.CommissionerNumber.ToString()
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
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},

                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = obj.MeetingInfo.IsDirectorsBoardMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = obj.MeetingInfo.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = obj.MeetingInfo.IsBudgetRegular},

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
            ManagerInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},

                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = obj.MeetingInfo.IsDirectorsBoardMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = obj.MeetingInfo.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = obj.MeetingInfo.IsBudgetRegular},

                new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = obj.CooEmployeeInfo.EmployeeName},
                new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = obj.CooEmployeeInfo.EmployeeNationalId},
                new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = obj.CooEmployeeInfo.EmployeeBirthDate},

                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = obj.CooEmployeeInfo.EmployeeHireDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = obj.CooEmployeeInfo.EmployeeQualification},

                new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = obj.CooEmployeeInfo.EmployeeSpecialistCD},
                new SpInPuts(){KEY = "P_SBSD_EMP_YEAR_SALARY_CD" , VALUE = obj.SalaryForWhichYear},

                new SpInPuts(){KEY = "P_SBSD_EMP_CONTRACT_FLG" , VALUE = obj.CooEmployeeInfo.IsThereJobContract},
                new SpInPuts(){KEY = "P_SBSD_EMP_FULLTIME_FLG" , VALUE = obj.IsDirectorDedicatedForJob},

                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_BOD_AGREE_FLG" , VALUE = obj.CooEmployeeInfo.AppointmentBoardApproval},
                new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = obj.AnnualSalary},
                new SpInPuts(){KEY = "P_SBSD_EMP_PRIVILEGES" , VALUE = obj.CooEmployeeInfo.OtherPrivileges},

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
                    obj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertReassigningAccountantDAL(
            AccountantInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},

                new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = obj.CooEmployeeInfo.EmployeeName},
                new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = obj.CooEmployeeInfo.EmployeeBirthDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = obj.CooEmployeeInfo.EmployeeNationalId},

                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = obj.CooEmployeeInfo.EmployeeHireDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = obj.CooEmployeeInfo.EmployeeSpecialistCD},

                new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = obj.CooEmployeeInfo.EmployeeQualification},
                new SpInPuts(){KEY = "P_BALSHT_SAL_SPRT_FLG" , VALUE = obj.AccountantSalarySeparateInTheBudget},

                new SpInPuts(){KEY = "P_SBSD_EMP_CONTRACT_FLG" , VALUE = obj.IsContractSignedbotheAndNameAndSalaryShown},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_BOD_AGREE_FLG" , VALUE = obj.CooEmployeeInfo.AppointmentBoardApproval},

                new SpInPuts(){KEY = "P_SPONSOR_FLG" , VALUE = obj.IsNonSaudiSponsorshipOnAgancy},
                new SpInPuts(){KEY = "P_PAYROLL_FLG" , VALUE = obj.IsAccountantReceiptSheetAvailable},

                new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = obj.AnnualSalary},
                new SpInPuts(){KEY = "P_SBSD_EMP_PRIVILEGES" , VALUE = obj.CooEmployeeInfo.OtherPrivileges},
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
                    obj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }


        public RequestResult InsertInsertBuildHeadquartertDAL(
           HeadquarterInfo obj,
           List<Files> Files
           )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = obj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = obj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_CEO_NAME" , VALUE = obj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "P_CEO_MOB_NO" , VALUE = obj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "P_PARTNERS_FLAG" , VALUE = obj.IsAgencyHaveSupportedBeforeInRebuild},
                new SpInPuts(){KEY = "P_PARTNERS_FUND_SUPPORT" , VALUE = obj.AmountOfSupported},
                new SpInPuts(){KEY = "P_PARTNERS_LIST" , VALUE = obj.AgencyOfSupported},
                new SpInPuts(){KEY = "P_LAND_INSTRUMENT_FLG" , VALUE = obj.IsAgencyHaveLandToBuild},
                new SpInPuts(){KEY = "P_PROJ_REG_SHARE_AMNT" , VALUE = obj.AmountForProjectAsNumber},
                new SpInPuts(){KEY = "P_PROJ_EXPEND_BAL_AMNT" , VALUE = obj.ExpendedOnProjectInBudget},
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
                "CS_P_SUBSIDY_BUILDUP",
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
