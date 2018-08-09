using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Cooperative
{
    /// <summary>
    /// بيانات المدير
    /// </summary>
    [DataContract]
    public class ManagersInfo
    {
        /// <summary>
        /// اسم رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_NAME
        /// </summary>
        [DataMember(Order = 0)]
        public string ChairmanBoardName { get; set; }

        /// <summary>
        /// رقم جوال رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_MOBILE
        /// </summary>
        [DataMember(Order = 1)]
        public long ChairmanBoardMobileNumber { get; set; }

        /// <summary>
        /// اسم المدير التنفيذي
        /// CEO_NAME
        /// </summary>
        [DataMember(Order = 2)]
        public string ExecutiveDirectorName { get; set; }

        /// <summary>
        /// جوال المدير التنفيذي
        /// CEO_MOB_NO
        /// </summary>
        [DataMember(Order = 3)]
        public long ExecutiveDirectorMobile { get; set; }
    }
}
