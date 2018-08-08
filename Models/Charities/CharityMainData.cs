using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Charities
{
    [DataContract(Namespace = "CharityMainData")]
    public class CharityMainData
    {
        /// <summary>
        /// نوع الجهه
        /// P_REG_TYPE_CODE  
        /// </summary>
        [DataMember]
        public int CharityType { get; set; }

        /// <summary>
        /// رقم الترخيص
        /// P_REG_ID
        /// </summary>
        [DataMember]
        public long LicenseNumber { get; set; }

        /// <summary>
        /// رقم هوية المفوض 
        /// P_LOGIN_ID
        /// </summary>
        [DataMember]
        public string CommissionerNumber { get; set; }

        /// <summary>
        /// نوع الإعانة
        /// P_SUBSIDY_CODE
        /// </summary>
        [DataMember]
        public int SubsidyType { get; set; }

        /// <summary>
        /// عدد المستفيدين من الجمعية
        /// P_BENEF_COUNT
        /// </summary>
        [DataMember]
        public int BeneficiariesCount { get; set; }

        /// <summary>
        /// عدد المتطوعين
        /// P_VOLUNTEERS_COUNT
        /// </summary>
        [DataMember]
        public int VolunteersCount { get; set; }

        /// <summary>
        /// عدد الموظفين السعودين
        /// P_EMP_SA_COUNT
        /// </summary>
        [DataMember]
        public int SaudiEmployeesCount { get; set; }

        /// <summary>
        /// عدد الموظفين الغير سعودين
        /// P_EMP_NONSA_COUNT
        /// </summary>
        [DataMember]
        public int NonSaudiEmployeesCount { get; set; }

        /// <summary>
        /// هل صدرت الميزانية
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [DataMember]
        public int IsbudgetIssued { get; set; }

        /// <summary>
        /// هل اجتماعات مجلس الإدارة منتظمة أو غير منتظمة
        /// P_BOARD_MEET_FLG
        /// </summary>
        [DataMember]
        public int IsBoardOfDirectorsMeetingsRegular { get; set; }

        /// <summary>
        /// هل اجتماعات الجمعية العمومية منتظمة أو غير منتظمة
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [DataMember]
        public int IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// سبب عدم انتظام اجتماعاعت الجمعية العمومية
        /// P_PUB_BOARD_MEET_REASON
        /// </summary>
        [DataMember]
        public string GeneralAssemblyIrregularityMeetingReason { get; set; }

        /// <summary>
        /// إجمالي المصروفات العمومية والإدارية خلال العام السابق
        /// P_LAST_YEAR_EXPENSES
        /// </summary>
        [DataMember]
        public decimal TotalExpensesAdministrativePreviousYear { get; set; }

        /// <summary>
        /// إجمالي المصروفات على الأنشطة والبرامج خلال العام السابق
        /// P_LAST_YEAR_ROG_EXPENSES
        /// </summary>
        [DataMember]
        public decimal TotalExpensesForActivitiesPreviousYear { get; set; }

        /// <summary>
        /// عدد البرامج المنفذة خلال العام السابق
        /// P_LAST_YEAR_PRG_COUNT
        /// </summary>
        [DataMember]
        public int ProgramsImplementedPreviousYearCount { get; set; }

        /// <summary>
        /// نتيجة تقييم زيارة الحوكمة
        /// P_MAKEEN_EAVL_RESULT
        /// </summary>
        [DataMember]
        public int GovernmentEvaluationResult { get; set; }

        /// <summary>
        /// نبذة عن البرنامج او المشروع
        /// P_PROG_SUMMARY
        /// </summary>
        [DataMember]
        public string BriefAboutEmergencyAssembly { get; set; }

        /// <summary>
        /// هل يوجد شركاء للجمعية 
        /// P_PARTNERS_FLAG
        /// </summary>
        [DataMember]
        public int AreTherePartners { get; set; }

        /// <summary>
        /// اسماء شركاء الجمعية
        /// P_PARTNERS_LIST
        /// </summary>
        [DataMember]
        public string PartnerNames { get; set; }

        /// <summary>
        /// اجمالي دعم الشركاء للمشروع من التكاليف الاجمالية
        /// P_PARTNERS_FUND_SUPPORT
        /// </summary>
        [DataMember]
        public decimal TotalPartnerSupport { get; set; }

        /// <summary>
        /// المبلغ المطلوب من الوزارة
        /// P_PROG_REQUEST_AMOUNT
        /// </summary>
        [DataMember]
        public string RequiredSubsidy { get; set; }
    }
}
