using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Common
{
    [DataContract]
    public class RequestResult
    {
        [DataMember(EmitDefaultValue = false)]
        public long RequestId { get; set; }

        [DataMember]
        public string RequestCode { get; set; }

        [DataMember]
        public string RequestName { get; set; }
    }
}
