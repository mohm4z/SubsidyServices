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
    [DataContract(Namespace = "ProjectInfo")]
    public class ProjectInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// هل توجد دراسة جدوى اقتصادية للمشروع
        /// ECONOMIC_FEASIBILITY_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public int IsThereFeasibilityStudy { get; set; }

        /// <summary>
        /// نوع المشروع
        /// PROJ_TYPE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public string ProjectType { get; set; }

        /// <summary>
        /// وصف المشروع
        /// PROJ_DESC
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public string ProjectDescription { get; set; }

        /// <summary>
        /// موقع المشروع/منطقة خدمات المشروع
        /// PROJ_LOCATION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public string ProjectLocation { get; set; }

        /// <summary>
        /// الجهة المنفذة للمشروع
        /// PROJ_EXEC_REGION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public string ExecutingAgency { get; set; }

        /// <summary>
        /// هل توجد موافقة على تنفيذ المشروع
        /// PROJ_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public int IsThereImplementProjectAgreement { get; set; }

        /// <summary>
        /// التكلفة الفعلية للمشروع
        /// PROJ_ACTUAL_COST
        /// </summary>
        [DataMember(Order = 8)]
        public decimal ActualCost { get; set; }

        /// <summary>
        /// توزيع المبالغ على مراحل المشروع
        /// PROJ_STAGES_FUND
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        public string DistributeAmountsOnStages { get; set; }

        /// <summary>
        /// هل المبلغ المصروف في بيان الصرف مطابق مع ماظهر في الميزانية
        /// PROJ_EXPNS_CMBTL_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 10)]
        public int IsExpendedIdenticalBudget { get; set; }

        /// <summary>
        /// المبلغ الذي تم رصده من قبل الجمعية للمشروع
        /// PROJ_REG_SHARE_AMNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 11)]
        public decimal AmountForProject { get; set; }

        /// <summary>
        /// المبلغ المصروف على المشروع الظاهر في الميزانية
        /// PROJ_EXPEND_BAL_AMNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 12)]
        public decimal AmountExpendedOnBudget { get; set; }
      

    }
}
