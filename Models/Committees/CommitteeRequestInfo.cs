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
        /// P_SUBSIDY_CODE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 1)]
        public int SubsidyType { get; set; }

        /// <summary>
        /// السنة المالية
        /// P_FIN_YEAR
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 8)]
        [DataMember(Order = 2)]
        public int FinancialYear { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public List<Project> Projects { get; set; }

    }
}
