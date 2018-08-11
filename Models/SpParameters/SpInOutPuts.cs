using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
//using System.Runtime.Serialization;


namespace Models.SpParameters
{
    //[DataContract]
    public class SpInOutPuts
    {
        //[DataMember]
        public string ParameterName { get; set; }

        //[DataMember]
        public OracleDbType OracleDbType { get; set; }

        //[DataMember]
        public object Value { get; set; }

        //[DataMember]
        public int Size { get; set; }
    }
}
