﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Charities
{
    [DataContract(Namespace = "CharityMainData")]
    public class CharityMainData
    {
        /// <summary>
        /// نوع الإعانة
        /// P_SUBSIDY_CODE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 3)]
        [DataMember(Order = 0)]
        public int SubsidyType { get; set; }

        /// <summary>
        /// عدد المستفيدين من الجمعية
        /// P_BENEF_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 7)]
        [DataMember(Order = 1)]
        public int BeneficiariesCount { get; set; }

        /// <summary>
        /// عدد المتطوعين
        /// P_VOLUNTEERS_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 5)]
        [DataMember(Order = 2)]
        public int VolunteersCount { get; set; }

        /// <summary>
        /// عدد الموظفين السعودين
        /// P_EMP_SA_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 5)]
        [DataMember(Order = 3)]
        public int SaudiEmployeesCount { get; set; }

        /// <summary>
        /// عدد الموظفين الغير سعودين
        /// P_EMP_NONSA_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 5)]
        [DataMember(Order = 4)]
        public int NonSaudiEmployeesCount { get; set; }

        /// <summary>
        /// هل صدرت الميزانية
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 5)]
        public int IsbudgetIssued { get; set; }

        /// <summary>
        /// هل اجتماعات مجلس الإدارة منتظمة أو غير منتظمة
        /// P_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 6)]
        public int IsBoardOfDirectorsMeetingsRegular { get; set; }

        /// <summary>
        /// هل اجتماعات الجمعية العمومية منتظمة أو غير منتظمة
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 7)]
        public int IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// سبب عدم انتظام اجتماعاعت الجمعية العمومية
        /// P_PUB_BOARD_MEET_REASON
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 8)]
        public string GeneralAssemblyIrregularityMeetingReason { get; set; }

        /// <summary>
        /// إجمالي المصروفات العمومية والإدارية خلال العام السابق
        /// P_LAST_YEAR_EXPENSES
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 9)]
        public decimal TotalExpensesAdministrativePreviousYear { get; set; }

        /// <summary>
        /// إجمالي المصروفات على الأنشطة والبرامج خلال العام السابق
        /// P_LAST_YEAR_ROG_EXPENSES
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 10)]
        public decimal TotalExpensesForActivitiesPreviousYear { get; set; }

        /// <summary>
        /// عدد البرامج المنفذة خلال العام السابق
        /// P_LAST_YEAR_PRG_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 5)]
        [DataMember(Order = 11)]
        public int ProgramsImplementedPreviousYearCount { get; set; }

        /// <summary>
        /// نتيجة تقييم زيارة الحوكمة
        /// P_MAKEEN_EAVL_RESULT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 5)]
        [DataMember(Order = 12)]
        public int GovernmentEvaluationResult { get; set; }

        /// <summary>
        /// نبذة عن البرنامج او المشروع
        /// P_PROG_SUMMARY
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 13)]
        public string BriefAboutEmergencyAssembly { get; set; }

        /// <summary>
        /// هل يوجد شركاء للجمعية 
        /// P_PARTNERS_FLAG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 14)]
        public int AreTherePartners { get; set; }

        /// <summary>
        /// اسماء شركاء الجمعية
        /// P_PARTNERS_LIST
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 15)]
        public string PartnerNames { get; set; }

        /// <summary>
        /// اجمالي دعم الشركاء للمشروع من التكاليف الاجمالية
        /// P_PARTNERS_FUND_SUPPORT
        /// </summary>
        //[ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 16)]
        public decimal TotalPartnerSupport { get; set; }

        /// <summary>
        /// المبلغ المطلوب من الوزارة
        /// P_PROG_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 17)]
        public decimal RequiredSubsidy { get; set; }
    }
}
