using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    [DataContract]
    public class FoundationInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// راس مال الجمعية بداية التأسيس
        /// P_ESTBLSH_CAPITAL
        /// </summary>
        [DataMember(Order = 12)]
        public decimal CompanyCapitalInBeginning { get; set; }

        [DataMember(Order = 13)]
        public RequestResult RequestResult { get; set; }
    }
}
