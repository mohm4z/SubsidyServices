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
    /// بيانات خدمة البحوث
    /// </summary>
    [DataContract(Namespace = "ResearchInfo")]
    public class ResearchInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// موضوع البحث أو الدراسة
        /// P_RSRCH_SUBJECT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 3)]
        public string ResearchSubject { get; set; }

        /// <summary>
        /// محاور البحث
        /// P_RSRCH_GOOLS
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 4)]
        public string ResearchGools { get; set; }

        /// <summary>
        /// علاقة البحث أو الدراسة بنشاط الجمعية
        /// P_RSRCH_SUBJECT_ACTIVITIES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 5)]
        public string ActivityResearchRelationship { get; set; }

        /// <summary>
        /// هل يوجد قرار مجلس الإدارة بالموافقة على اجراء الدراسة والبحث وتحديد محاورة
        /// P_RSRCH_BOD_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 6)]
        public int IsThereApprovalForResearch { get; set; }

        /// <summary>
        /// هل توجد موافقة الوزارة على اجراء البحث والدراسة
        /// P_RSRCH_MINISTRY_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 7)]
        public int IsThereApprovalFromMinistryForResearch { get; set; }

        /// <summary>
        /// التكلفة المقدرة لإنجاز الدراسة او البحث رقماً
        /// P_RSRCH_EXPECTED_COST
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 8)]
        public decimal CostForResearchAsNumber { get; set; }

        /// <summary>
        /// الجهات التي تم الصرف عليها
        /// P_SOCIALS_SPENT_ON
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 9)]
        public string AgenciesDisbursedOnIt { get; set; }

        /// <summary>
        /// هل تم ارفاق بيان بالتكلفة المقدرة لإنجاز الدراسة او البحث
        /// P_RSRCH_COST_LETTER_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 10)]
        public int IsCostStatementBeenAttached { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 11)]
        public decimal RequiredSubsidy { get; set; }
    }
}
