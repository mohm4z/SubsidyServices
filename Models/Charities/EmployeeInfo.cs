using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Charities
{
    /// <summary>
    /// معلومات الموظف
    /// </summary>
    [DataContract(Namespace = "EmployeeInfo")]
    public class EmployeeInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        /// <summary>
        /// نوع الإعانة
        /// P_SUBSIDY_CODE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 1)]
        public int SubsidyType { get; set; }

        /// <summary>
        /// اسم رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_NAME
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public string ChairmanBoardName { get; set; }

        /// <summary>
        /// رقم جوال رئيس مجلس الادارة
        /// P_BOARD_CHAIRMAN_MOBILE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public long ChairmanBoardMobileNumber { get; set; }

        /// <summary>
        /// اسم المدير
        /// P_SBSD_EMP_NAME
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public string EmployeeName { get; set; }

        /// <summary>
        /// تاريخ التعيين
        /// P_SBSD_EMP_HIRE_DT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public string EmployeeHireDate { get; set; }

        /// <summary>
        /// رقم الهوية الوطنية
        /// P_SBSD_EMP_ID
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public long EmployeeNationalId { get; set; }

        /// <summary>
        /// تاريخ الميلاد
        /// P_SBSD_EMP_BDATE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public string EmployeeBirthDate { get; set; }

        /// <summary>
        /// الجنسية
        /// P_SBSD_EMP_NATIONALITY
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 8)]
        public string EmployeeNationality { get; set; }

        /// <summary>
        /// المؤهل التعليمي
        /// P_SBSD_EMP_QUALIF_CD
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 9)]
        public int EmployeeQualification { get; set; }

        /// <summary>
        /// التخصص ، يدخل في حالة الباحث
        /// P_SBSD_EMP_SPECIALIST_CD
        /// </summary>
        //[ItsRequired]
        [DataMember(Order = 10)]
        public string EmployeeSpecialistCD { get; set; }

        /// <summary>
        /// الخبرة
        /// P_SBSD_EMP_EXPR_PRD_CD
        /// </summary>
        //[ItsRequired]
        [DataMember(Order = 11)]
        public string EmployeeExpertise { get; set; }

        /// <summary>
        /// الراتب الشهري الاساسي
        /// P_SBSD_EMP_SALARY
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 12)]
        public decimal EmployeeSalary { get; set; }

        /// <summary>
        /// قيمة بدل السكن
        /// P_SBSD_EMP_RENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 13)]
        public decimal EmployeeRentAmount { get; set; }



    }
}
