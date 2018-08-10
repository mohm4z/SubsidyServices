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
    /// بيانات المدير
    /// </summary>
    [DataContract(Namespace = "AccountantInfo")]
    public class ManagerInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2)]
        public CooEmployeeInfo CooEmployeeInfo { get; set; }

        /// <summary>
        /// اجتماعات مجلس الإدارة
        /// P_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public string DirectorsBoardMeetings { get; set; }

        /// <summary>
        /// اجتماعات الجمعية العمومية
        /// P_PUB_BOARD_MEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order =4)]
        public string IsGeneralAssemblyMeetingsRegular { get; set; }

        /// <summary>
        /// ميزانياتها العمومية وحساباتها منتظمة
        /// P_BALANCE_SHEET_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public string IsBudgetRegular { get; set; }

        /// <summary>
        /// راتب السنه
        /// P_SBSD_EMP_YEAR_SALARY_CS
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public string SalaryForWhichYear { get; set; }

        /// <summary>
        /// هل المدير متفرغ لأعمال الجمعية
        /// P_SBSD_EMP_FULLTIME_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public string IsDirectorDedicatedForJob { get; set; }

        /// <summary>
        /// مقدار الراتب:
        /// P_SBSD_EMP_SALARY
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 8)]
        public string AnnualSalary { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        public string RequiredSubsidy { get; set; }


    }
}
