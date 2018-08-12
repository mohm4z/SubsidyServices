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
    /// بيانات خدمة الخسائر
    /// </summary>
    [DataContract(Namespace = "LossInfo")]
    public class LossInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// نوع الخسارة أو الضرر الحاصل.
        /// P_RISK_DESC
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public string LossType { get; set; }

        /// <summary>
        /// هل توجد محاضر رسمية تثبت تحقق الظروف القاهرة وقيمة الاضرار
        /// P_RISK_PROOF_LETTERS_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public int IsThereRecordsProvingDamagesAndValue { get; set; }

        /// <summary>
        /// هل تم عقد اجتماع مجلس الإدارة عن الموضوع
        /// P_RISK_BOD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public int IsBoardMeetAboutThisSubject { get; set; }

        /// <summary>
        /// هل تم توضح حجم الخسائر  في الميزانية العمومية
        /// P_RISK_BALSHT_LOST_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public int IsLossesAppearInBalanceSheet { get; set; }

        /// <summary>
        /// قيمة الخسائر والاضرار رقماً
        /// P_RISK_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public decimal LossesValueAsNumber { get; set; }

        /// <summary>
        /// المبلغ المصروف على المشروع الظاهر في الميزانية
        /// P_RISK_BALSHT_SPENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 8)]
        public decimal ProjectAmountShownInBudget { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        public decimal RequiredSubsidy { get; set; }

    }
}
