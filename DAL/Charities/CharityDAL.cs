using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Charities;
using Oracle.ManagedDataAccess.Client;
using Models.SpParameters;
using System.Data;
using Models.Common;

namespace DAL.Charities
{
    public class CharityDAL : IDisposable
    {
        public readonly IADO ado;

        public CharityDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        /// <summary>
        /// حفظ بيانات الاعانة التأسيسية
        /// </summary>
        /// <param name="chda"></param>
        /// <param name="ChairmanBoardMobileNumber"></param>
        /// <param name="ChairmanBoardName"></param>
        /// <returns></returns>
        public RequestResult InsertFoundationSubsidyDAL(
            CheckedData chda,
            string ChairmanBoardMobileNumber,
            string ChairmanBoardName
            //List<Files> Files
            )
        {

            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = chda.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = chda.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = chda.CommissionerNumber}
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
                "CH_P_SUBSIDY_ESTBLSH",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            return RequestResult;
        }

        /// <summary>
        /// حفظ بيانات اعانة الموظفين
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertEmployeeSubsidyDAL(
            EmployeeInfo emp,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emp.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = emp.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = emp.SubsidyType},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = emp.ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = emp.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_SBSD_EMP_NAME" , VALUE = emp.EmployeeName},
                new SpInPuts(){KEY = "P_SBSD_EMP_HIRE_DT" , VALUE = emp.EmployeeHireDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_ID" , VALUE = emp.EmployeeNationalId},
                new SpInPuts(){KEY = "P_SBSD_EMP_BDATE" , VALUE = emp.EmployeeBirthDate},
                new SpInPuts(){KEY = "P_SBSD_EMP_NATIONALITY" , VALUE = emp.EmployeeNationality},
                new SpInPuts(){KEY = "P_SBSD_EMP_QUALIF_CD" , VALUE = emp.EmployeeQualification},
                new SpInPuts(){KEY = "P_SBSD_EMP_SPECIALIST" , VALUE = emp.EmployeeSpecialist},
                new SpInPuts(){KEY = "P_SBSD_EMP_SPECIALIST_CD" , VALUE = emp.EmployeeSpecialistCD},
                new SpInPuts(){KEY = "P_SBSD_EMP_EXPR_PRD_CD" , VALUE = emp.EmployeeExpertise},
                new SpInPuts(){KEY = "P_SBSD_EMP_SALARY" , VALUE = emp.EmployeeSalary},
                new SpInPuts(){KEY = "P_SBSD_EMP_RENT_AMOUNT" , VALUE = emp.EmployeeRentAmount},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emp.CheckedData.CommissionerNumber}
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
                "CH_P_SUBSIDY_EMP",
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
                    emp.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return RequestResult;
        }

        /// <summary>
        /// حفظ بيانات الإعانة الطارئة
        /// </summary>
        /// <param name="emg"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertEmergencySubsidyDAL(
            EmergencyInfo emg,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emg.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = emg.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = emg.CharityMainData.SubsidyType},
                new SpInPuts(){KEY = "P_BENEF_COUNT" , VALUE = emg.CharityMainData.BeneficiariesCount},
                new SpInPuts(){KEY = "P_VOLUNTEERS_COUNT" , VALUE = emg.CharityMainData.VolunteersCount},
                new SpInPuts(){KEY = "P_EMP_SA_COUNT" , VALUE = emg.CharityMainData.SaudiEmployeesCount},
                new SpInPuts(){KEY = "P_EMP_NONSA_COUNT" , VALUE = emg.CharityMainData.NonSaudiEmployeesCount},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = emg.CharityMainData.IsbudgetIssued},
                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = emg.CharityMainData.IsBoardOfDirectorsMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = emg.CharityMainData.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_REASON" , VALUE = emg.CharityMainData.GeneralAssemblyIrregularityMeetingReason},
                new SpInPuts(){KEY = "P_LAST_YEAR_EXPENSES" , VALUE = emg.CharityMainData.TotalExpensesAdministrativePreviousYear},
                new SpInPuts(){KEY = "P_LAST_YEAR_ROG_EXPENSES" , VALUE = emg.CharityMainData.TotalExpensesForActivitiesPreviousYear},
                new SpInPuts(){KEY = "P_LAST_YEAR_PRG_COUNT" , VALUE = emg.CharityMainData.ProgramsImplementedPreviousYearCount},
                new SpInPuts(){KEY = "P_MAKEEN_EAVL_RESULT" , VALUE = emg.CharityMainData.GovernmentEvaluationResult},
                new SpInPuts(){KEY = "P_SBSD_STATUS_DESC" , VALUE = emg.CharityMainData.BriefAboutEmergencyAssembly},
                new SpInPuts(){KEY = "P_SBSD_STATUS_REASONS" , VALUE = emg.Causes},
                new SpInPuts(){KEY = "P_SBSD_STATUS_PROCEDURES" , VALUE = emg.ActionsTaken},
                new SpInPuts(){KEY = "P_PARTNERS_FLAG" , VALUE = emg.CharityMainData.AreTherePartners},
                new SpInPuts(){KEY = "P_PARTNERS_LIST" , VALUE = emg.CharityMainData.PartnerNames},
                new SpInPuts(){KEY = "P_PARTNERS_FUND_SUPPORT" , VALUE = emg.CharityMainData.TotalPartnerSupport},
                new SpInPuts(){KEY = "P_CURR_BALANCE" , VALUE = emg.BankBalance},
                new SpInPuts(){KEY = "P_REQUEST_AMOUNT" , VALUE = emg.CharityMainData.RequiredSubsidy},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emg.CheckedData.CommissionerNumber}
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
                "CH_P_SUBSIDY_EMRGNCY",
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
                    emg.CheckedData.CommissionerNumber
                    );
            }

            return RequestResult;
        }

        /// <summary>
        /// حفظ بيانات الاعانه الانشائية
        /// </summary>
        /// <param name="cnst"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertConstructSubsidyDAL(
            ConstructInfo cnst,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = cnst.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = cnst.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = cnst.CharityMainData.SubsidyType},
                new SpInPuts(){KEY = "P_BENEF_COUNT" , VALUE = cnst.CharityMainData.BeneficiariesCount},
                new SpInPuts(){KEY = "P_VOLUNTEERS_COUNT" , VALUE = cnst.CharityMainData.VolunteersCount},
                new SpInPuts(){KEY = "P_EMP_SA_COUNT" , VALUE = cnst.CharityMainData.SaudiEmployeesCount},
                new SpInPuts(){KEY = "P_EMP_NONSA_COUNT" , VALUE = cnst.CharityMainData.NonSaudiEmployeesCount},
                new SpInPuts(){KEY = "P_BALANCE_SHEET_FLG" , VALUE = cnst.CharityMainData.IsbudgetIssued},
                new SpInPuts(){KEY = "P_BOARD_MEET_FLG" , VALUE = cnst.CharityMainData.IsBoardOfDirectorsMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_FLG" , VALUE = cnst.CharityMainData.IsGeneralAssemblyMeetingsRegular},
                new SpInPuts(){KEY = "P_PUB_BOARD_MEET_REASON" , VALUE = cnst.CharityMainData.GeneralAssemblyIrregularityMeetingReason},
                new SpInPuts(){KEY = "P_LAST_YEAR_EXPENSES" , VALUE = cnst.CharityMainData.TotalExpensesAdministrativePreviousYear},
                new SpInPuts(){KEY = "P_LAST_YEAR_ROG_EXPENSES" , VALUE = cnst.CharityMainData.TotalExpensesForActivitiesPreviousYear},
                new SpInPuts(){KEY = "P_LAST_YEAR_PRG_COUNT" , VALUE = cnst.CharityMainData.ProgramsImplementedPreviousYearCount},
                new SpInPuts(){KEY = "P_MAKEEN_EAVL_RESULT" , VALUE = cnst.CharityMainData.GovernmentEvaluationResult},
                new SpInPuts(){KEY = "P_PROG_NAME" , VALUE = cnst.ProgramName},
                new SpInPuts(){KEY = "P_PROG_AUDIENCES" , VALUE = cnst.TargetedPeoples},
                new SpInPuts(){KEY = "P_PROG_SUMMARY" , VALUE = cnst.CharityMainData.BriefAboutEmergencyAssembly},
                new SpInPuts(){KEY = "P_PROG_GOALS" , VALUE = cnst.ProgramGoals},
                new SpInPuts(){KEY = "P_IMPLEMENTATION_DT" , VALUE = cnst.ImplementationDate},
                new SpInPuts(){KEY = "P_IMPLEMENTATION_DESC" , VALUE = cnst.ImplementationMethod},
                new SpInPuts(){KEY = "P_IMPLEMENTATION_DURATION" , VALUE = cnst.ImplementationDuration},
                new SpInPuts(){KEY = "P_TOTAL_PROG_COST" , VALUE = cnst.TotalCost},
                new SpInPuts(){KEY = "P_PARTNERS_FLAG" , VALUE = cnst.CharityMainData.AreTherePartners},
                new SpInPuts(){KEY = "P_PARTNERS_LIST" , VALUE = cnst.CharityMainData.PartnerNames},
                new SpInPuts(){KEY = "P_PARTNERS_FUND_SUPPORT" , VALUE = cnst.CharityMainData.TotalPartnerSupport},
                new SpInPuts(){KEY = "P_PROG_GOALS_CMPTBL_FLAG" , VALUE = cnst.CompatibilityOfProgramsWithObjectives},
                new SpInPuts(){KEY = "P_PROG_REQUEST_AMOUNT" , VALUE = cnst.CharityMainData.RequiredSubsidy},
                new SpInPuts(){KEY = "P_ORG_FUND_SUPPORT" , VALUE = cnst.AllocatedAmountToProject},
                new SpInPuts(){KEY = "P_ORG_FUND_SUPPORT_PRCNT" , VALUE = cnst.AllocatedPercentageToProject},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = cnst.CheckedData.CommissionerNumber}
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
                "CH_P_SUBSIDY_BUILDUP",
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
                    cnst.CheckedData.CommissionerNumber
                    );
            }

            return RequestResult;
        }

        /// <summary>
        /// حفظ المرفقات
        /// </summary>
        /// <param name="RequestId"></param>
        /// <param name="FileNumber"></param>
        /// <param name="FilePath"></param>
        /// <param name="CommissionerNumber"></param>
        /// <returns></returns>
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
