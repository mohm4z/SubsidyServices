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
using DAL.Common;
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

        public CharityInfo GetCharityInfoDAL(
             long LicenseNumber,
             int CharityType
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = LicenseNumber},
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = CharityType}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_BRN_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_REG_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_REGISTRY_DT" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_SERVICE_AREA" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_SUBSIDY_ACC_NO" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_BANK_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_CAT_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_NO_700" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                "CH_P_CH_REG_INFO",
                OpParms,
                out OracleParameterCollection OPCs
                );

            CharityInfo chi = new CharityInfo
            {
                DevelopmentCenterName = OPCs[":P_BRN_NAME"].Value.ToString(),
                CharityName = OPCs[":P_REG_NAME"].Value.ToString(),
                LicenseDate = OPCs[":P_REGISTRY_DT"].Value.ToString(),
                ServiceArea = OPCs[":P_SERVICE_AREA"].Value.ToString(),
                BankAccountNumber = OPCs[":P_SUBSIDY_ACC_NO"].ToString(),
                BankName = OPCs[":P_BANK_NAME"].Value.ToString(),
                CharityClassification = OPCs[":P_CAT_NAME"].Value.ToString(),
                AccountNumber700 = OPCs[":P_NO_700"].Value.ToString() != null ? Convert.ToInt64(OPCs[":P_NO_700"].Value.ToString()) : 0,

                RequestResult = new RequestResult()
                {
                    ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }


        public CharityGoals GetCharityGoalsDAL(
            long LicenseNumber,
            int CharityType
           )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = LicenseNumber},
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = CharityType}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                "CH_P_GET_REG_GOALS",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            CharityGoals chi = new CharityGoals
            {
                Goals = Ds.Tables[0].DataTableToList<Goals>(),
                RequestResult = new RequestResult()
                {
                    ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }


        public CharityFiles GetCharityFilesDAL(
           long SubsidyCode
          )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = SubsidyCode}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                "CH_P_GET_SUBSIDY_FILES",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            CharityFiles chi = new CharityFiles
            {
                Files = Ds.Tables[0].DataTableToList<Files>(),
                RequestResult = new RequestResult()
                {
                    ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }


        public RequestResult InsertFoundationSubsidyDAL(
            int CharityType,
            long LicenseNumber,
            long ChairmanBoardMobileNumber,
            string ChairmanBoardName,
            long CommissionerNumber,
            List<Files> Files
          )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = CharityType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = LicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = ChairmanBoardName},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    CommissionerNumber.ToString()
                    );
            }

            return chi;
        }


        public RequestResult InsertEmployeeSubsidyDAL(
            EmployeeInfo emp,
            List<Files> Files
         )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emp.CharityType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = emp.LicenseNumber},
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
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emp.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    emp.CommissionerNumber.ToString()
                    );
            }

            return chi;
        }


        public RequestResult InsertEmergencySubsidyDAL(
           EmergencyInfo emg,
           List<Files> Files
         )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emg.CharityMainData.CharityType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = emg.CharityMainData.LicenseNumber},
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
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emg.CharityMainData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    emg.CharityMainData.CommissionerNumber
                    );
            }

            return chi;
        }


        public RequestResult InsertConstructSubsidyDAL(
           EmergencyInfo emg,
           List<Files> Files
         )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = emg.CharityMainData.CharityType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = emg.CharityMainData.LicenseNumber},
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
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = emg.CharityMainData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Int32 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    emg.CharityMainData.CommissionerNumber
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
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
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
                ErrorCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                ErrorName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            return chi;
        }



        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
