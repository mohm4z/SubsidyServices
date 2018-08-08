using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;
using Models.Common;

namespace Models.Charities
{
    [DataContract(Namespace = "ConstructInfo")]
    public class ConstructInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public CharityMainData CharityMainData { get; set; }

        /// <summary>
        /// اسم البرنامج او المشروع
        /// P_PROG_NAME
        /// </summary>
        [DataMember(Order = 2)]
        public string ProgramName { get; set; }

        /// <summary>
        /// المستهدفين
        /// P_PROG_AUDIENCES
        /// </summary>
        [DataMember(Order = 3)]
        public string TargetedPeoples { get; set; }

        /// <summary>
        /// اهداف البرنامج او المشروع
        /// P_PROG_GOALS
        /// </summary>
        [DataMember(Order = 4)]
        public string ProgramGoals { get; set; }

        /// <summary>
        /// تاريخ التنفيذ
        /// P_IMPLEMENTATION_DT
        /// </summary>
        [DataMember(Order = 5)]
        public string ImplementationDate { get; set; }

        /// <summary>
        /// طريقة التنفيذ
        /// P_IMPLEMENTATION_DESC
        /// </summary>
        [DataMember(Order = 6)]
        public string ImplementationMethod { get; set; }

        /// <summary>
        /// مدة التنفيذ
        /// P_IMPLEMENTATION_DURATION
        /// </summary>
        [DataMember(Order = 7)]
        public decimal ImplementationDuration { get; set; }

        /// <summary>
        /// التكلفة الاجمالية للمشروع
        /// P_TOTAL_PROG_COST
        /// </summary>
        [DataMember(Order = 8)]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// مدى توافق البرنامج او المشروع مع اهداف الجمعية و نشاطها
        /// P_PROG_GOALS_CMPTBL_FLAG
        /// </summary>
        [DataMember(Order = 9)]
        public decimal CompatibilityOfProgramsWithObjectives { get; set; }

        /// <summary>
        /// إجمالي ما تم رصدة للمشروع من الجمعية.
        /// P_ORG_FUND_SUPPORT
        /// </summary>
        [DataMember(Order = 10)]
        public decimal AllocatedAmountToProject { get; set; }

        /// <summary>
        /// نسبة ما تم رصدة للمشروع %
        /// P_ORG_FUND_SUPPORT_PRCNT
        /// </summary>
        [DataMember(Order = 11)]
        public decimal AllocatedPercentageToProject { get; set; }

    }
}
