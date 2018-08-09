using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    [DataContract]
    public class BoardDirectorsRemunerationInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }


        /// <summary>
        /// اجتماعات الجمعية العمومية
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [DataMember(Order = 2)]
        public string IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// ميزانياتها العمومية وحساباتها منتظمة
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [DataMember(Order = 3)]
        public string IsBudgetRegular { get; set; }


        /// <summary>
        /// هل حققت الجمعية أرباحا بموجب اخر ميزانية صدرت لها؟
        /// P_PROFIT_FLG
        /// </summary>
        [DataMember(Order = 4)]
        public string IsAssociationMadeProfitsInlastbudget { get; set; }

        /// <summary>
        /// مقدار الربح المحقق بعد خصم مخصص الزكاة:
        /// P_PROFIT_AFTER_ZAKAT_AMNT
        /// </summary>
        [DataMember(Order = 5)]
        public string ProfitsAfterZakat { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [DataMember(Order = 6)]
        public string ManagersInfo { get; set; }
    }
}
