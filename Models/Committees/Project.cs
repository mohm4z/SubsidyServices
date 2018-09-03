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
        [Length(MaxLength = 13)]
        [DataMember(Order = 2)]
        public decimal CivilContributionKind { get; set; }

        /// <summary>
        /// فائض من العام الماضي
        /// P_EX_GOV_REV_CASH
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 3)]
        public decimal LastYearSurplus { get; set; }

        /// <summary>
        /// رمز المبادرة
        /// P_INITIATIVE_NO
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 4)]
        public int InitiativeCode { get; set; }

        /// <summary>
        /// البرنامج
        /// SD,32
        /// P_PROGRAM_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 5)]
        public int TheProgram { get; set; }

        /// <summary>
        /// التصنيف
        /// CH_P_GET_LOOKUPS_DET(SD,31,:VAR1)
        /// P_PROJ_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 6)]
        public decimal Classification { get; set; }

        /// <summary>
        /// اسم المشروع
        /// P_PROG_NAME
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 150)]
        [DataMember(Order = 7)]
        public string ProjectName { get; set; }

        /// <summary>
        /// نوع مدة المشروع
        /// FIXED
        /// يوم ، شهر
        /// P_PROJ_DURATION_TYPE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 8)]
        public string ProjectDurationType { get; set; }

        /// <summary>
        /// مدة المشروع
        /// P_PROJ_DURATION
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 9)]
        public int ProjectDuration { get; set; }

        /// <summary>
        /// فكرة و اهداف المشروع
        /// P_PROG_GOALS
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 10)]
        public string ProjectGoals { get; set; }

        /// <summary>
        /// رسوم الاشتراك
        /// P_REQ_SUBSCRIPTION_FEES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 11)]
        public decimal SubscriptionFee { get; set; }

        /// <summary>
        /// وضع المشروع
        /// 1  مستحدث
        /// 2  قائم
        /// P_PROJ_SITUATION
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 12)]
        public int ProjectStatus { get; set; }

        /// <summary>
        /// عدد المستفيدين المتوقع
        /// P_EXP_BEN_CNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 7)]
        [DataMember(Order = 13)]
        public int BeneficiariesExpectedNumber { get; set; }

        /// <summary>
        /// نوع المقر
        /// SD,6
        /// P_RESIDENCE_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 14)]
        public int HeadquarterType { get; set; }

        /// <summary>
        /// عدد الموظفين
        /// P_PRJ_EMP_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 4)]
        [DataMember(Order = 15)]
        public int EmployeesNumber { get; set; }

        /// <summary>
        /// قيمة الايجار
        /// P_RENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 16)]
        public decimal RentAmount { get; set; }

        /// <summary>
        /// اجمالي رواتب الموظفين
        /// P_PRJ_SALARIES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 17)]
        public decimal TotalEmployeeSalaries { get; set; }

        /// <summary>
        /// قيمة الاعيان الثابتة
        /// P_PRJ_FIXEDASSETS
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 18)]
        public decimal FixedAssetsValue { get; set; }

        /// <summary>
        /// المصروفات الأخرى
        /// P_PRJ_EXPENSES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 19)]
        public decimal OtherExpenses { get; set; }
    }
}
