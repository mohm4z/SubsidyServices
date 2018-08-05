using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Charities;
using Oracle.ManagedDataAccess.Client;
using Models.SpParameters;

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
                new SpOutPuts() { ParameterName ="P_SUBSIDY_ACC_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_BANK_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_CAT_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_NO_700" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_NO_700" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
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


            CharityInfo chi = new CharityInfo();

            return chi;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
