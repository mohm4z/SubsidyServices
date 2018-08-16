using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Common
{
    [DataContract(Namespace = "Subsidy")]
    public class Subsidy
    {
        [DataMember(Order = 0)]
        public string AgencyType { get; set; }

        [DataMember(Order = 8)]
        public string SubsidyCode { get; set; }

        [DataMember(Order = 9)]
        public string SubsidyName { get; set; }

        [DataMember(Order = 0)]
        public string AgencyName { get; set; }
    }
}
