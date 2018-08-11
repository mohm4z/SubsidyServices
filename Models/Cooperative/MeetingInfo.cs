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
    /// معلومات الإجتماعات
    /// </summary>
    public class MeetingInfo
    {

        /// <summary>
        /// اجتماعات مجلس الإدارة
        /// P_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public int IsDirectorsBoardMeetingsRegular { get; set; }

        /// <summary>
        /// اجتماعات الجمعية العمومية
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public int IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// ميزانياتها العمومية وحساباتها منتظمة
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public int IsBudgetRegular { get; set; }

    }
}
