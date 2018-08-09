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
    /// ملعلومات المحاسب
    /// </summary>
    [DataContract]
    public class AccountantInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2)]
        public CooEmployeeInfo CooEmployeeInfo { get; set; }

        /// <summary>
        /// ظهرت رواتب المحاسب منفصلة عن رواتب الموظفين في الميزانية
        /// P_BALSHT_SAL_SPRT_FLG
        /// </summary>
        [DataMember(Order = 3)]
        public int AccountantSalarySeparateInTheBudget { get; set; }

        /// <summary>
        /// عقد العمل بين الجمعية والمحاسب موقع من الطرفين وموضح به اسم المحاسب ومقدار الراتب
        /// P_SBSD_EMP_CONTRACT_FLG
        /// </summary>
        [DataMember(Order = 4)]
        public int IsContractSignedbotheAndNameAndSalaryShown { get; set; }

        /// <summary>
        /// المحاسب (غير السعودي) على كفالة الجمعية.
        /// P_SPONSOR_FLG
        /// </summary>
        [DataMember(Order = 5)]
        public int IsNonSaudiSponsorshipOnAgancy { get; set; }

        /// <summary>
        /// بيان باستلام المحاسب للرواتب
        /// P_PAYROLL_FLG
        /// </summary>
        [DataMember(Order = 6)]
        public int IsAccountantReceiptSheetAvailable { get; set; }

        /// <summary>
        /// مقدار الراتب:
        /// P_SBSD_EMP_SALARY
        /// </summary>
        [DataMember(Order = 8)]
        public string AnnualSalary { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [DataMember(Order = 9)]
        public string RequiredSubsidy { get; set; }

    }
}
