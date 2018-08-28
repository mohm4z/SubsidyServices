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
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        /// <summary>
        /// نوع الاعانة
        /// SUBSIDY_CODE
        /// </summary>
        [DataMember(Order = 1)]
        public int SubsidyType { get; set; }

        /// <summary>
        /// السنة المالية
        /// FIN_YEAR
        /// </summary>
        [DataMember(Order = 2)]
        public int FinancialYear { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public List<Project> Projects { get; set; }

    }
}
