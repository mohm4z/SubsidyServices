using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Committees
{
    /// <summary>
    /// بيانات المشروع
    /// </summary>
    [DataContract(Namespace = "Project")]
    public class Project
    {
        /// <summary>
        /// المساهمة الحكومية المقترحة
        /// PROG_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 0)]
        public decimal ProposedGovernmentContribution { get; set; }

        /// <summary>
        /// مساهمة أهلية نقدية
        /// CME_REV_CASH
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 1)]
        public decimal CivilMonetaryContribution { get; set; }

        /// <summary>
        /// عينية
        /// CME_REV_ITEMS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public decimal CivilContributionKind { get; set; }

        /// <summary>
        /// فائض من العام الماضي
        /// EX_GOV_REV_CASH
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public decimal LastYearSurplus { get; set; }

        /// <summary>
        /// رمز المبادرة
        /// INITIATIVE_NO
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public int InitiativeCode { get; set; }

        /// <summary>
        /// البرنامج
        /// SD,32
        /// PROGRAM_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public int TheProgram { get; set; }

        /// <summary>
        /// التصنيف
        /// CH_P_GET_LOOKUPS_DET(SD,31,:VAR1)
        /// PROJ_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public decimal Classification { get; set; }

        /// <summary>
        /// اسم المشروع
        /// PROG_NAME
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public string ProjectName { get; set; }

        /// <summary>
        /// نوع مدة المشروع
        /// FIXED
        /// يوم ، شهر
        /// PROJ_DURATION_TYPE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 8)]
        public string ProjectDurationType { get; set; }

        /// <summary>
        /// مدة المشروع
        /// PROJ_DURATION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        public int ProjectDuration { get; set; }

        /// <summary>
        /// فكرة و اهداف المشروع
        /// PROG_GOALS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 10)]
        public decimal ProjectGoals { get; set; }

        /// <summary>
        /// رسوم الاشتراك
        /// REQ_SUBSCRIPTION_FEES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 11)]
        public decimal SubscriptionFee { get; set; }

        /// <summary>
        /// وضع المشروع
        /// 1  مستحدث
        /// 2  قائم
        /// PROJ_SITUATION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 12)]
        public int ProjectStatus { get; set; }

        /// <summary>
        /// عدد المستفيدين المتوقع
        /// EXP_BEN_CNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 13)]
        public int BeneficiariesExpectedNumber { get; set; }

        /// <summary>
        /// نوع المقر
        /// SD,6
        /// RESIDENCE_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 14)]
        public int HeadquarterType { get; set; }

        /// <summary>
        /// عدد الموظفين
        /// PRJ_EMP_COUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 15)]
        public int EmployeesNumber { get; set; }

        /// <summary>
        /// قيمة الايجار
        /// RENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 16)]
        public decimal RentAmount { get; set; }

        /// <summary>
        /// اجمالي رواتب الموظفين
        /// PRJ_SALARIES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 17)]
        public decimal TotalEmployeeSalaries { get; set; }

        /// <summary>
        /// قيمة الاعيان الثابتة
        /// PRJ_FIXEDASSETS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 18)]
        public decimal FixedAssetsValue { get; set; }

        /// <summary>
        /// المصروفات الأخرى
        /// PRJ_EXPENSES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 19)]
        public decimal OtherExpenses { get; set; }
    }
}
