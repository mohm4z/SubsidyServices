using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Common
{
    [DataContract(Namespace = "FinancialYears")]
    public class FinancialYears
    {
        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string EndDate { get; set; }

        [DataMember]
        public string FinancialYear { get; set; }

        [DataMember]
        public string Year { get; set; }

    }
}
