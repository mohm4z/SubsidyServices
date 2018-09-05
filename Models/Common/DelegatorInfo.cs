using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Common
{
    /// <summary>
    /// بيانات المفوض
    /// </summary>
    [DataContract(Namespace = "DelegatorInfo")]
    public class DelegatorInfo
    {
        /// <summary>
        /// P_REG_ID
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 50)]
        [DataMember(Order = 0)]
        public string REG_ID { get; set; }

        /// <summary>
        /// P_DLGT_ID
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 15)]
        [DataMember(Order = 1)]
        public string DLGT_ID { get; set; }

        /// <summary>
        /// P_REG_TYPE_CODE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2)]
        [DataMember(Order = 2)]
        public int REG_TYPE_CODE { get; set; }

        /// <summary>
        /// P_SUBSIDY_CODE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 3)]
        public int SUBSIDY_CODE { get; set; }
    }
}
