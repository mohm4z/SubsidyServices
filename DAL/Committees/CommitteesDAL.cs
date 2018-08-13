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

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
