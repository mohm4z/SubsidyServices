using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Common;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Cooperative
{
    class CooperativeDAL : IDisposable
    {
        public readonly IADO ado;

        public CooperativeDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public void GetLookupDAL(
           string ApplicationCode,
           int TabNumber
          )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_APPLICATION_CODE  " , VALUE = ApplicationCode},
                new SpInPuts(){KEY = "P_TAB_NO" , VALUE = TabNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Int32 , Size = 100},
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
                "CH_P_GET_LOOKUPS",
                OpParms,
                out OracleParameterCollection OPCs
                );

            //return Ds.Tables[0].DataTableToList<LookupTable>();
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
