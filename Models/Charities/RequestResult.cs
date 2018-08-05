using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Charities
{
    [DataContract]
    public class RequestResult
    {
        [DataMember(EmitDefaultValue = false)]
        public long RequestId { get; set; }

        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorName { get; set; }
    }
}
