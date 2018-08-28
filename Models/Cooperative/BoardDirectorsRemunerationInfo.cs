using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    [DataContract(Namespace = "BoardDirectorsRemunerationInfo")]
    public class BoardDirectorsRemunerationInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// هل حققت الجمعية أرباحا بموجب اخر ميزانية صدرت لها؟
        /// P_PROFIT_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public int IsAssociationMadeProfitsInlastbudget { get; set; }

        /// <summary>
        /// مقدار الربح المحقق بعد خصم مخصص الزكاة:
        /// P_PROFIT_AFTER_ZAKAT_AMNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public decimal ProfitsAfterZakat { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public decimal RequiredSubsidy { get; set; }
    }
}
