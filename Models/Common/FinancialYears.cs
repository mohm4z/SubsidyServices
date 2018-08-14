using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Common
{
    /// <summary>
    /// بانات السنوات المالية
    /// </summary>
    [DataContract(Namespace = "FinancialYears")]
    public class FinancialYears
    {
        [DataMember(Order = 0)]
        public string StartDate { get; set; }

        [DataMember(Order = 1)]
        public string EndDate { get; set; }

        [DataMember(Order = 2)]
        public string FinancialYear { get; set; }

        [DataMember(Order = 3)]
        public string Year { get; set; }

    }
}
