using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Data;
//using System.Data.SqlClient;

//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Dynamic;
using System.Xml.Linq;
using Models.SpParameters;

namespace DAL.DbManager
{
    public class ADO : IADO, IDisposable
    {
        private OracleTransaction SqlTrans;

        private OracleConnection conn;

        private OracleCommand cmd;

        private readonly string ConnS =
        //"SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=ServerDB)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));uid=ulp;pwd=ulp;unicode=true;"
        //"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=ServerDB)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=main;Password=main;";
        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.250.125.83)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=mosawh)));User Id=ch;Password=chmosa;";
        //"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=ServerDB)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ORCL)));User Id=main;Password=main;"

        public ADO()
        {
            conn = new OracleConnection(ConnS);

            cmd = new OracleCommand
            {
                Connection = conn
            };

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public ADO(bool Trans)
        {
            conn = new OracleConnection(ConnS);
            cmd = new OracleCommand();
            cmd.Connection = conn;
            //cmd.BindByName = true;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlTrans = conn.BeginTransaction();
            cmd.Transaction = SqlTrans;
        }

        public bool SqlCommand(string Statment)
        {
            cmd.CommandText = Statment;

            int Result = cmd.ExecuteNonQuery();

            if (Result > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteStoredProcedure(
            in string SP_NAME,
            in List<OracleParameter> parms,
            out OracleParameterCollection OPC,
            out DataSet DS
            )
        {
            cmd.CommandText = SP_NAME;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parms.ToArray());

            cmd.ExecuteNonQuery();

            OPC = cmd.Parameters;

            DS = new DataSet("DsTables");

            for (int i = 0; i < parms.Count(); i++)
            {
                if (parms[i].OracleDbType == OracleDbType.RefCursor)
                {
                    DS.Tables.Add(new DataTable(parms[i].ParameterName));

                    OracleDataReader dr1 = ((OracleRefCursor)parms[i].Value).GetDataReader();

                    DS.Tables[parms[i].ParameterName].Load(dr1);

                    break;
                }
            }
        }

        public void ExecuteStoredProcedure(
            in string SP_NAME,
            in List<OracleParameter> parms,
            out OracleParameterCollection OPC
            )
        {
            cmd.CommandText = SP_NAME;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parms.ToArray());

            cmd.ExecuteNonQuery();

            OPC = cmd.Parameters;
        }

        public bool SqlCommiteT(bool Commite)
        {
            try
            {
                if (Commite)
                {
                    SqlTrans.Commit();
                    return true;
                }
                else
                {
                    SqlTrans.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                SqlTrans.Rollback();
                return false;
            }
        }

        public DataTable SqlSelect(string Statment)
        {
            cmd.CommandText = Statment;

            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            return dt;
        }

        public DataRow SqlSelectOneRow(string Statment)
        {
            cmd.CommandText = Statment;

            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public object SqlSelectOneValue(string Statment)
        {
            cmd.CommandText = Statment;

            return cmd.ExecuteScalar();
        }

        public object Nullable(object value)
        {
            return value ?? DBNull.Value;
        }

        private void PopulateNullParameters()
        {
            foreach (OracleParameter p in cmd.Parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
        }

        #region General Methods

        public List<OracleParameter> PopulateSpInPuts(
            in List<SpInPuts> spInPuts
            )
        {
            List<OracleParameter> OpParms = new List<OracleParameter>();

            foreach (SpInPuts spin in spInPuts)
            {
                OpParms.Add(new OracleParameter()
                {
                    ParameterName = ":" + spin.KEY,
                    Value =  spin.VALUE?.ToString()
                });
            }

            return OpParms;
        }

        public void PopulateSpOutPuts(
            ref List<OracleParameter> OpParams,
            in List<SpOutPuts> sqOutPuts
            )
        {
            for (int i = 0; i < sqOutPuts.Count(); i++)
            {
                OpParams.Add(new OracleParameter()
                {
                    ParameterName = ":" + sqOutPuts[i].ParameterName,
                    OracleDbType = sqOutPuts[i].OracleDbType,
                    Direction = ParameterDirection.Output,
                    Size = sqOutPuts[i].Size
                });
            }
        }

        public void PopulateSpInOutPuts(
            ref List<OracleParameter> OpParams,
            in List<SpInOutPuts> InOutPuts
            )
        {
            for (int i = 0; i < InOutPuts.Count(); i++)
            {
                OpParams.Add(new OracleParameter()
                {
                    ParameterName = ":" + InOutPuts[i].ParameterName,
                    OracleDbType = InOutPuts[i].OracleDbType,
                    Direction = ParameterDirection.InputOutput,
                    Value = InOutPuts[i]?.Value,
                    Size = InOutPuts[i].Size
                });
            }
        }

        public ExpandoObject CreateExapoClass(
            ref OracleParameterCollection OPCs
            )
        {
            dynamic exapoy = new ExpandoObject();

            foreach (OracleParameter opc in OPCs)
            {
                if (opc.Direction == ParameterDirection.Output)
                {
                    var expandoDict = exapoy as IDictionary<string, object>;

                    if (expandoDict.ContainsKey(opc.ParameterName.Remove(0, 1)))
                        expandoDict[opc.ParameterName.Remove(0, 1)] = opc.Value.ToString();
                    else
                        expandoDict.Add(opc.ParameterName.Remove(0, 1), opc.Value.ToString());
                }
            }

            return exapoy;
        }

        public XElement CreateXElement(
            in string T_NAME,
            ref OracleParameterCollection OPCs
            )
        {
            XNamespace aw = "mlsd";
            XElement xmlTree = new XElement(aw +T_NAME);

            //xmlTree.Document.Root.Descendants();

            foreach (OracleParameter opc in OPCs)
            {
                if (opc.Direction == ParameterDirection.Output)
                {
                    xmlTree.Add(
                        new XElement(aw + opc.ParameterName.Remove(0, 1), opc.Value)
                        );
                }
            }

            return xmlTree;
        }

        #endregion

        public void Dispose()
        {
            try
            {
                conn.Dispose();
                cmd.Dispose();
                if (SqlTrans != null) { SqlTrans.Dispose(); }
            }
            catch (Exception)
            { }
        }
    }

}
