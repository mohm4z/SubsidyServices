using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    /// <summary>
    /// بيانات المدراء
    /// </summary>
    [DataContract(Namespace = "ManagersInfo")]
    public class ManagersInfo
    {
        /// <summary>
        /// اسم رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_NAME
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 150)]
        [DataMember(Order = 0)]
        public string ChairmanBoardName { get; set; }

        /// <summary>
        /// رقم جوال رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_MOBILE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12)]
        [DataMember(Order = 1)]
        public long ChairmanBoardMobileNumber { get; set; }

        /// <summary>
        /// اسم المدير التنفيذي
        /// P_CEO_NAME
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 150)]
        [DataMember(Order = 2)]
        public string ExecutiveDirectorName { get; set; }

        /// <summary>
        /// جوال المدير التنفيذي
        /// P_CEO_MOB_NO
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12)]
        [DataMember(Order = 3)]
        public long ExecutiveDirectorMobile { get; set; }
    }
}
