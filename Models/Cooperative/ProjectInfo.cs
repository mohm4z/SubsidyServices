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
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// هل توجد دراسة جدوى اقتصادية للمشروع
        /// P_ECONOMIC_FEASIBILITY_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 2)]
        public int IsThereFeasibilityStudy { get; set; }

        /// <summary>
        /// نوع المشروع
        /// P_PROJ_TYPE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 100)]
        [DataMember(Order = 3)]
        public string ProjectType { get; set; }

        /// <summary>
        /// وصف المشروع
        /// P_PROJ_DESC
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 4)]
        public string ProjectDescription { get; set; }

        /// <summary>
        /// موقع المشروع/منطقة خدمات المشروع
        /// P_PROJ_LOCATION
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 200)]
        [DataMember(Order = 5)]
        public string ProjectLocation { get; set; }

        /// <summary>
        /// الجهة المنفذة للمشروع
        /// P_PROJ_EXEC_REGION
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 150)]
        [DataMember(Order = 6)]
        public string ExecutingAgency { get; set; }

        /// <summary>
        /// هل توجد موافقة على تنفيذ المشروع
        /// P_PROJ_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 7)]
        public int IsThereImplementProjectAgreement { get; set; }

        /// <summary>
        /// التكلفة الفعلية للمشروع
        /// P_PROJ_ACTUAL_COST
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 8)]
        public int ActualCost { get; set; }

        /// <summary>
        /// توزيع المبالغ على مراحل المشروع
        /// P_PROJ_STAGES_FUND
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 9)]
        public string DistributeAmountsOnStages { get; set; }

        /// <summary>
        /// هل المبلغ المصروف في بيان الصرف مطابق مع ماظهر في الميزانية
        /// P_PROJ_EXPNS_CMBTL_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 10)]
        public int IsExpendedIdenticalBudget { get; set; }

        /// <summary>
        /// المبلغ الذي تم رصده من قبل الجمعية للمشروع
        /// P_PROJ_REG_SHARE_AMNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 11)]
        public int AmountForProject { get; set; }

        /// <summary>
        /// المبلغ المصروف على المشروع الظاهر في الميزانية
        /// P_PROJ_EXPEND_BAL_AMNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 12)]
        public int AmountExpendedOnBudget { get; set; }
      

    }
}
