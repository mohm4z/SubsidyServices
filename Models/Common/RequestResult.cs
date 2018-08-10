using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Common
{
    /// <summary>
    /// نتيجة الإتصال وإضافة وتحديث البيانات في قواعد البيانات
    /// </summary>
    [DataContract(Namespace = "RequestResult")]
    public class RequestResult
    {
        [DataMember(Order = 0, EmitDefaultValue = false)]
        public long RequestId { get; set; }

        [DataMember(Order = 1)]
        public string RequestCode { get; set; }

        [DataMember(Order = 2)]
        public string RequestName { get; set; }
    }
}
