using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Charities
{
    /// <summary>
    /// بيانات الإعانة الطارئة
    /// </summary>
    [DataContract(Namespace = "EmergencyInfo")]
    public class EmergencyInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public CharityMainData CharityMainData { get; set; }

        /// <summary>
        /// مسببات الحالة
        /// P_SBSD_STATUS_REASONS
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 2)]
        public string Causes { get; set; }

        /// <summary>
        /// الإجراءات التي تم اتخاذها لمواجهة الحالة
        /// P_SBSD_STATUS_PROCEDURES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 3)]
        public string ActionsTaken { get; set; }

        /// <summary>
        /// الرصيد المتوفر في حساب الجمعية
        /// P_CURR_BALANCE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12.2)]
        [DataMember(Order = 4)]
        public decimal BankBalance { get; set; }

        
    }
}
