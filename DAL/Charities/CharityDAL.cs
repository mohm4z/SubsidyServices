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
using DAL.CommonHelpers;

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
                RegistrationDate = OPCs[":P_REGISTRY_DT"].Value.ToString(),
                ServiceArea = OPCs[":P_SERVICE_AREA"].Value.ToString(),
                BankAccountNumber = OPCs[":P_SUBSIDY_ACC_NO"].Value != null ? Convert.ToInt64(OPCs[":P_SUBSIDY_ACC_NO"].Value.ToString()) : 0,
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
                Goals= Ds.Tables[0].DataTableToList<Goals>(),
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


        public RequestResult InsertDAL(
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

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
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
