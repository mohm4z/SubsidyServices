using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Committees
{
    /// <summary>
    /// بيانات طلب الجهه
    /// </summary>
    [DataContract(Namespace = "CommitteeRequestInfo")]
    public class CommitteeRequestInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public int SubsidyType { get; set; }

        [DataMember(Order = 1)]
        public int FinancialYear { get; set; }

        [DataMember(Order = 1)]
        public List<Project> Projects { get; set; }

    }
}
