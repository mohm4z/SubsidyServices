using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;


namespace Models.Charities
{
    [DataContract]
    public class ConstructInfo
    {
        [DataMember]
        public CharityMainData CharityMainData { get; set; }





        /// <summary>
        /// اسم البرنامج او المشروع
        /// </summary>
        [DataMember]
        public string ProgramName { get; set; }

        /// <summary>
        /// المستهدفين
        /// </summary>
        [DataMember]
        public string TargetedPeoples { get; set; }

        /// <summary>
        /// اهداف البرنامج او المشروع
        /// </summary>
        [DataMember]
        public string ProgramGoals { get; set; }

        /// <summary>
        /// تاريخ التنفيذ
        /// 
        /// </summary>
        [DataMember]
        public string ImplementationDate { get; set; }

        /// <summary>
        /// طريقة التنفيذ
        /// </summary>
        [DataMember]
        public string ImplementationMethod { get; set; }

        /// <summary>
        /// مدة التنفيذ
        /// </summary>
        [DataMember]
        public decimal ImplementationDuration { get; set; }

        /// <summary>
        /// التكلفة الاجمالية للمشروع
        /// </summary>
        [DataMember]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// مدى توافق البرنامج او المشروع مع اهداف الجمعية و نشاطها
        /// P_PROG_GOALS_CMPTBL_FLAG
        /// </summary>
        [DataMember]
        public decimal CompatibilityOfProgramsWithObjectives { get; set; }

        /// <summary>
        /// إجمالي ما تم رصدة للمشروع من الجمعية.
        /// P_ORG_FUND_SUPPORT
        /// </summary>
        [DataMember]
        public long AllocatedAmountToProject { get; set; }


        /// <summary>
        /// نسبة ما تم رصدة للمشروع %
        /// P_ORG_FUND_SUPPORT_PRCNT
        /// </summary>
        [DataMember]
        public long AllocatedPercentageToProject { get; set; }
        
    }

    
}
