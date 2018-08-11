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
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// عدد المشاركين
        /// P_PARTICIPANTS_COUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public int ParticipantsCount { get; set; }


        /// <summary>
        /// اسماء المتدربين
        /// P_PARTICIPANTS_NAMES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public string TraineesNames { get; set; }

        /// <summary>
        /// نوع المشاركة
        /// P_PARTICIPATION_TYPE_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public int ParticipationType { get; set; }

        ///// <summary>
        ///// 
        ///// 
        ///// </summary>
        //[ItsRequired]
        //[DataMember(Order = 6)]
        //public int ParticipantsCount { get; set; }


        ///// <summary>
        ///// مكان المشاركة
        ///// P_PARTICIPANTS_LOCATION
        ///// </summary>
        //[ItsRequired]
        //[DataMember(Order = 7)]
        //public int ParticipantsCount { get; set; }

        ///// <summary>
        ///// 
        ///// 
        ///// </summary>
        //[ItsRequired]
        //[DataMember(Order = 8)]
        //public int ParticipantsCount { get; set; }

        ///// <summary>
        ///// 
        ///// 
        ///// </summary>
        //[ItsRequired]
        //[DataMember(Order = 9)]
        //public int ParticipantsCount { get; set; }

    }
}
