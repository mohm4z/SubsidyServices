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
    /// معلومات المشروع
    /// </summary>
    [DataContract]
    class ProjectInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        /// <summary>
        /// اسم رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_NAME
        /// </summary>
        [DataMember(Order = 1)]
        public string ChairmanBoardName { get; set; }

        /// <summary>
        /// رقم جوال رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_MOBILE
        /// </summary>
        [DataMember(Order = 2)]
        public long ChairmanBoardMobileNumber { get; set; }

        /// <summary>
        /// اسم المدير التنفيذي
        /// CEO_NAME
        /// </summary>
        [DataMember(Order = 3)]
        public string ExecutiveDirectorName { get; set; }

        /// <summary>
        /// جوال المدير التنفيذي
        /// CEO_MOB_NO
        /// </summary>
        [DataMember(Order = 4)]
        public long ExecutiveDirectorMobile { get; set; }

        /// <summary>
        /// هل توجد دراسة جدوى اقتصادية للمشروع
        /// ECONOMIC_FEASIBILITY_FLG
        /// </summary>
        [DataMember(Order = 5)]
        public int IsThereFeasibilityStudy { get; set; }

        /// <summary>
        /// نوع المشروع
        /// PROJ_TYPE
        /// </summary>
        [DataMember(Order = 6)]
        public string ProjectType { get; set; }

        /// <summary>
        /// وصف المشروع
        /// PROJ_DESC
        /// </summary>
        [DataMember(Order = 7)]
        public string ProjectDescription { get; set; }

        /// <summary>
        /// موقع المشروع/منطقة خدمات المشروع
        /// PROJ_LOCATION
        /// </summary>
        [DataMember(Order = 8)]
        public string ProjectLocation { get; set; }

        /// <summary>
        /// الجهة المنفذة للمشروع
        /// PROJ_EXEC_REGION
        /// </summary>
        [DataMember(Order = 9)]
        public string ExecutingAgency { get; set; }

        /// <summary>
        /// هل توجد موافقة على تنفيذ المشروع
        /// PROJ_AGREE_FLG
        /// </summary>
        [DataMember(Order = 10)]
        public int ImplementProjectAgreement { get; set; }

        /// <summary>
        /// التكلفة الفعلية للمشروع
        /// PROJ_ACTUAL_COST
        /// </summary>
        [DataMember(Order = 11)]
        public decimal ActualCost { get; set; }

        /// <summary>
        /// توزيع المبالغ على مراحل المشروع
        /// PROJ_STAGES_FUND
        /// </summary>
        [DataMember(Order = 12)]
        public string DistributeAmountsOnStages { get; set; }

        /// <summary>
        /// هل المبلغ المصروف في بيان الصرف مطابق مع ماظهر في الميزانية
        /// PROJ_EXPNS_CMBTL_FLG
        /// </summary>
        [DataMember(Order = 13)]
        public int IsExpendedIdenticalBudget { get; set; }

        /// <summary>
        /// المبلغ الذي تم رصده من قبل الجمعية للمشروع
        /// PROJ_REG_SHARE_AMNT
        /// </summary>
        [DataMember(Order = 14)]
        public decimal AmountForProject { get; set; }

        /// <summary>
        /// المبلغ المصروف على المشروع الظاهر في الميزانية
        /// PROJ_EXPEND_BAL_AMNT
        /// </summary>
        [DataMember(Order = 15)]
        public decimal AmountExpendedOnBudget { get; set; }

        [DataMember(Order = 16)]
        public RequestResult RequestResult { get; set; }

    }
}
