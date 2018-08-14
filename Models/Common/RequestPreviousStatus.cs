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
    [DataContract(Namespace = "RequestPreviousStatus")]
    public class RequestPreviousStatus
    {
        [DataMember(Order = 0, EmitDefaultValue = false)]
        public string RequestStatus { get; set; }

        [DataMember(Order = 1)]
        public string RequestCode { get; set; }

        [DataMember(Order = 2)]
        public string RequestName { get; set; }
    }
}
