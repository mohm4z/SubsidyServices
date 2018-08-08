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

       

        public RequestResult InsertFoundationSubsidyDAL(
            long CharityType,
            long LicenseNumber,
            string ChairmanBoardMobileNumber,
            string ChairmanBoardName,
            string CommissionerNumber
            //List<Files> Files
            )
        {

            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = CharityType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = LicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = ChairmanBoardName},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = CommissionerNumber}
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

            //List<OracleParameter> OpParms = new List<OracleParameter>()
            //{
            //     new OracleParameter(){ ParameterName=":P_REG_TYPE_CODE" , OracleDbType = OracleDbType.Int32 , Direction = ParameterDirection.Input , Value=CharityType  },
            //     new OracleParameter(){ ParameterName=":P_SOC_REG_ID" , OracleDbType = OracleDbType.Int32 , Direction = ParameterDirection.Input , Value= LicenseNumber  },
            //     new OracleParameter(){ ParameterName=":P_BOARD_CHAIRMAN_MOBILE" , OracleDbType = OracleDbType.Varchar2 , Direction = ParameterDirection.Input , Value= ChairmanBoardMobileNumber  },
            //     new OracleParameter(){ ParameterName=":P_BOARD_CHAIRMAN_NAME" , OracleDbType = OracleDbType.Varchar2 , Direction = ParameterDirection.Input , Value= ChairmanBoardName  },
            //     new OracleParameter(){ ParameterName=":P_LOGIN_ID" , OracleDbType = OracleDbType.Varchar2 , Direction = ParameterDirection.Input , Value= CommissionerNumber  },

            //     new OracleParameter(){ ParameterName=":P_REQUEST_ID" , OracleDbType = OracleDbType.Int32 , Direction = ParameterDirection.Output , Size= 100  },
            //     new OracleParameter(){ ParameterName=":P_REG_TYPE_CODE" , OracleDbType = OracleDbType.Int32 , Direction = ParameterDirection.InputOutput , Size= 100  },
            //     new OracleParameter(){ ParameterName=":P_REG_TYPE_CODE" , OracleDbType = OracleDbType.Varchar2 , Direction = ParameterDirection.InputOutput , Size= 100  }
            //};




            ado.ExecuteStoredProcedure(
                "CH_P_SUBSIDY_ESTBLSH",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),

                //RequestId = 1,
                //ErrorCode = "1",
                //ErrorName = "sss"
            };

            //for (int i = 0; i < Files.Count(); i++)
            //{
            //    InsertAttachmentDAL(
            //        chi.RequestId,
            //        Files[i].Id,
            //        Files[i].Path,
            //        CommissionerNumber
            //        );
            //}

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
                    emg.CharityMainData.CommissionerNumber
                    );
            }

            return chi;
        }

        public RequestResult InsertConstructSubsidyDAL(
           ConstructInfo cnst,
           List<Files> Files
         )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = cnst.CharityMainData.CharityType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = cnst.CharityMainData.LicenseNumber},
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
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = cnst.CharityMainData.CommissionerNumber}
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
                    cnst.CharityMainData.CommissionerNumber
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
