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
    [DataContract(Namespace = "MeetingInfo")]
    public class MeetingInfo
    {
        /// <summary>
        /// اجتماعات مجلس الإدارة
        /// P_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 0)]
        public int IsDirectorsBoardMeetingsRegular { get; set; }

        /// <summary>
        /// اجتماعات الجمعية العمومية
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 1)]
        public int IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// ميزانياتها العمومية وحساباتها منتظمة
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 2)]
        public int IsBudgetRegular { get; set; }

    }
}
