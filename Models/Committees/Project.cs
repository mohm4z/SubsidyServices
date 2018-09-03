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
        /// P_PROG_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 0)]
        public decimal ProposedGovernmentContribution { get; set; }

        /// <summary>
        /// مساهمة أهلية نقدية
        /// P_CME_REV_CASH
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 1)]
        public decimal CivilMonetaryContribution { get; set; }

        /// <summary>
        /// عينية
        /// P_CME_REV_ITEMS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        [Length(MaxLength = 13)]
        public decimal CivilContributionKind { get; set; }

        /// <summary>
        /// فائض من العام الماضي
        /// P_EX_GOV_REV_CASH
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        [Length(MaxLength = 13)]
        public decimal LastYearSurplus { get; set; }

        /// <summary>
        /// رمز المبادرة
        /// P_INITIATIVE_NO
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        [Length(MaxLength = 3)]
        public int InitiativeCode { get; set; }

        /// <summary>
        /// البرنامج
        /// SD,32
        /// P_PROGRAM_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        [Length(MaxLength = 3)]
        public int TheProgram { get; set; }

        /// <summary>
        /// التصنيف
        /// CH_P_GET_LOOKUPS_DET(SD,31,:VAR1)
        /// P_PROJ_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        [Length(MaxLength = 3)]
        public decimal Classification { get; set; }

        /// <summary>
        /// اسم المشروع
        /// P_PROG_NAME
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        [Length(MaxLength = 150)]
        public string ProjectName { get; set; }

        /// <summary>
        /// نوع مدة المشروع
        /// FIXED
        /// يوم ، شهر
        /// P_PROJ_DURATION_TYPE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 8)]
        [Length(MaxLength = 10)]
        public string ProjectDurationType { get; set; }

        /// <summary>
        /// مدة المشروع
        /// P_PROJ_DURATION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        [Length(MaxLength = 3)]
        public int ProjectDuration { get; set; }

        /// <summary>
        /// فكرة و اهداف المشروع
        /// P_PROG_GOALS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 10)]
        [Length(MaxLength = 2000)]
        public string ProjectGoals { get; set; }

        /// <summary>
        /// رسوم الاشتراك
        /// P_REQ_SUBSCRIPTION_FEES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 11)]
        [Length(MaxLength = 13)]
        public decimal SubscriptionFee { get; set; }

        /// <summary>
        /// وضع المشروع
        /// 1  مستحدث
        /// 2  قائم
        /// P_PROJ_SITUATION
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 12)]
        [Length(MaxLength = 1)]
        public int ProjectStatus { get; set; }

        /// <summary>
        /// عدد المستفيدين المتوقع
        /// P_EXP_BEN_CNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 13)]
        [Length(MaxLength = 7)]
        public int BeneficiariesExpectedNumber { get; set; }

        /// <summary>
        /// نوع المقر
        /// SD,6
        /// P_RESIDENCE_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 14)]
        [Length(MaxLength = 3)]
        public int HeadquarterType { get; set; }

        /// <summary>
        /// عدد الموظفين
        /// P_PRJ_EMP_COUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 15)]
        [Length(MaxLength = 4)]
        public int EmployeesNumber { get; set; }

        /// <summary>
        /// قيمة الايجار
        /// P_RENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 16)]
        [Length(MaxLength = 11)]
        public decimal RentAmount { get; set; }

        /// <summary>
        /// اجمالي رواتب الموظفين
        /// P_PRJ_SALARIES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 17)]
        [Length(MaxLength = 11)]
        public decimal TotalEmployeeSalaries { get; set; }

        /// <summary>
        /// قيمة الاعيان الثابتة
        /// P_PRJ_FIXEDASSETS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 18)]
        [Length(MaxLength = 13)]
        public decimal FixedAssetsValue { get; set; }

        /// <summary>
        /// المصروفات الأخرى
        /// P_PRJ_EXPENSES
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 19)]
        [Length(MaxLength = 11)]
        public decimal OtherExpenses { get; set; }
    }
}
