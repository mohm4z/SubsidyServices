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
    /// بيانات خدمة طلب تدريب
    /// </summary>
    [DataContract(Namespace = "TrainingInfo")]
    public class TrainingInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// عدد المشاركين
        /// P_PARTICIPANTS_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 3)]
        public int ParticipantsCount { get; set; }

        /// <summary>
        /// اسماء المتدربين
        /// P_PARTICIPANTS_NAMES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 500)]
        [DataMember(Order = 4)]
        public string TraineesNames { get; set; }

        /// <summary>
        /// نوع المشاركة
        /// P_PARTICIPATION_TYPE_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 5)]
        public int ParticipationType { get; set; }

        /// <summary>
        /// مكان المشاركة
        /// P_PARTICIPANTS_LOCATION
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 200)]
        [DataMember(Order = 6)]
        public string ParticipationLocation { get; set; }

        /// <summary>
        /// هل المتدرب من الأعضاء او العاملين بالجمعية؟
        /// P_PARTICIPANT_MEMBER_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 7)]
        public int IsTrainersFromAgency { get; set; }

        /// <summary>
        /// هل التدريب في موضوع له علاقة بأنشطة الجمعية؟ 
        /// P_PARTICIPATION_SUBJECT_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 8)]
        public int IsTrainingTopicRelatedToAgency { get; set; }

        /// <summary>
        /// التكلفة الفعلية 
        /// P_PARTICIPATION_ACTUAL_COST
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12.2)]
        [DataMember(Order = 9)]
        public decimal ActualCost { get; set; }

        /// <summary>
        /// هل تمت الموافقة على تخصيص (10%) من التكاليف لذلك
        /// P_PARTICIPATION_10PRCNT_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 10)]
        public int IsTheirApprovalToAllocateCosts { get; set; }

        /// <summary>
        ///هل تمت الموافقة على المشاركة من قبل الوزارة
        /// P_PARTICIPATION_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 11)]
        public int IsThereParticipationApproved { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12.2)]
        [DataMember(Order = 12)]
        public decimal RequiredSubsidy { get; set; }

    }
}
