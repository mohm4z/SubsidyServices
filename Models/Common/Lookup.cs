using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Common
{

   /// <summary>
   /// 
   /// </summary>
    [DataContract]
    public class Lookup
    {
        [DataMember]
        public IEnumerable<LookupTable> LookupTable { get; set; }

        [DataMember]
        public RequestResult RequestResult { get; set; }
    }

    /// <summary>
    /// الجداول الأساسية
    /// </summary>
    [DataContract]
    public class LookupTable
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
