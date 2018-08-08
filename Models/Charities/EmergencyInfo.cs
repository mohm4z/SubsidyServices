using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Charities
{
    /// <summary>
    /// بيانات الإعانة الطارئة
    /// </summary>
    [DataContract(Namespace = "EmergencyInfo")]
    public class EmergencyInfo
    {
        [DataMember(Order = 0)]
        public CharityMainData CharityMainData { get; set; }


        /// <summary>
        /// مسببات الحالة
        /// P_SBSD_STATUS_REASONS
        /// </summary>
        [DataMember(Order = 1)]
        public string Causes { get; set; }

        /// <summary>
        /// الإجراءات التي تم اتخاذها لمواجهة الحالة
        /// P_SBSD_STATUS_PROCEDURES
        /// </summary>
        [DataMember(Order = 2)]
        public string ActionsTaken { get; set; }

        /// <summary>
        /// الرصيد المتوفر في حساب الجمعية
        /// P_CURR_BALANCE
        /// </summary>
        [DataMember(Order = 3)]
        public decimal BankBalance { get; set; }

        
    }
}
