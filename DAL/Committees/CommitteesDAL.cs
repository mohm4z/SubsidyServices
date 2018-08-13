using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Common;
using DAL.DbManager;
using Models.Committees;
using Models.Common;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Committees
{
    public class CommitteesDAL : IDisposable
    {
        public readonly IADO ado;

        public CommitteesDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public CommitteeInfo GetCommitteeInfoDAL(
           int AgencyType,
           long AgencyLicenseNumber
           )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = AgencyLicenseNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_BRN_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_BRN_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_CME_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_CLASS_CD" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_IBAN_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_BANK_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_ACCOUNT_BALANCE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},

                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
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
                "SD_P_CH_REG_INFO",
                OpParms,
                out OracleParameterCollection OPCs
                );

            CommitteeInfo chi = new CommitteeInfo
            {
                DevelopmentCenterName = OPCs[":P_BRN_NAME"].Value.ToString(),
                DevelopmentCenterNumber = OPCs[":P_BRN_NO"].Value.ToString(),
                CommitteeName = OPCs[":P_CME_NAME"].Value.ToString(),
                CommitteeClassification = OPCs[":P_CLASS_CD"].Value.ToString(),
                BankAccountNumber = OPCs[":P_IBAN_NO"].Value.ToString(),
                BankName = OPCs[":P_BANK_NAME"].Value.ToString(),
                AccountBalance = OPCs[":P_ACCOUNT_BALANCE"].Value.ToString(),

                RequestResult = new RequestResult()
                {
                    RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }

        public IEnumerable<LookupTable> GetInitiativesDAL(
           )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_APPLICATION_CODE  " , VALUE = "SD"},
                //new SpInPuts(){KEY = "P_TAB_NO" , VALUE = TabNumber},
                //new SpInPuts(){KEY = "P_SUBTAB_NO" , VALUE = SubTabNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
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
                "SD_P_GET_INITIATIVES",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<LookupTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        public RequestResult InsertCommitteeServicesDAL(
            CommitteeRequestInfo obj,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = obj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = obj.SubsidyType},
                new SpInPuts(){KEY = "P_FIN_YEAR" , VALUE = obj.FinancialYear},
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
                "SD_P_SUBSIDY_REQUEST",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult RequestResult = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < obj.Projects.Count(); i++)
            {
                InsertProjectDAL(
                    RequestResult.RequestId,
                    obj.CheckedData.CommissionerNumber,
                    obj.Projects[i]
                    );
            }

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    RequestResult.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    obj.CheckedData.CommissionerNumber
                    );
            }

            return RequestResult;
        }

        public RequestResult InsertProjectDAL(
            long RequestId,
            string CommissionerNumber,
            Project obj
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REQUEST_ID" , VALUE = RequestId},
                new SpInPuts(){KEY = "PROG_REQUEST_AMOUNT" , VALUE = obj.ProposedGovernmentContribution},
                new SpInPuts(){KEY = "CME_REV_CASH" , VALUE = obj.CivilMonetaryContribution},
                new SpInPuts(){KEY = "CME_REV_ITEMS" , VALUE = obj.CivilContributionKind},
                new SpInPuts(){KEY = "EX_GOV_REV_CASH" , VALUE = obj.LastYearSurplus},
                new SpInPuts(){KEY = "PROG_NAME" , VALUE = obj.ProjectName},
                new SpInPuts(){KEY = "PROJ_DURATION_TYPE" , VALUE = obj.ProjectDurationType},
                new SpInPuts(){KEY = "PROJ_DURATION" , VALUE = obj.ProjectDuration},
                new SpInPuts(){KEY = "INITIATIVE_NO" , VALUE = obj.InitiativeCode},
                new SpInPuts(){KEY = "PROGRAM_CD" , VALUE = obj.TheProgram},
                new SpInPuts(){KEY = "PROJ_CD" , VALUE = obj.Classification},
                new SpInPuts(){KEY = "PROG_GOALS" , VALUE = obj.ProjectGoals},
                new SpInPuts(){KEY = "REQ_SUBSCRIPTION_FEES" , VALUE = obj.SubscriptionFee},
                new SpInPuts(){KEY = "PROJ_SITUATION" , VALUE = obj.ProjectStatus},
                new SpInPuts(){KEY = "EXP_BEN_CNT" , VALUE = obj.BeneficiariesExpectedNumber},
                new SpInPuts(){KEY = "RESIDENCE_CD" , VALUE = obj.HeadquarterType},
                new SpInPuts(){KEY = "PRJ_EMP_COUNT" , VALUE = obj.EmployeesNumber},
                new SpInPuts(){KEY = "RENT_AMOUNT" , VALUE = obj.RentAmount},
                new SpInPuts(){KEY = "PRJ_SALARIES" , VALUE = obj.TotalEmployeeSalaries},
                new SpInPuts(){KEY = "PRJ_FIXEDASSETS" , VALUE = obj.FixedAssetsValue},
                new SpInPuts(){KEY = "PRJ_EXPENSES" , VALUE = obj.OtherExpenses},
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
                "SD_P_SUBSIDY_PROJECTS",
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
