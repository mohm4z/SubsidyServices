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
    /// بيانات الموظف
    /// </summary>
    [DataContract]
    public class CooEmployeeInfo
    {
        /// <summary>
        /// اسم المدير
        /// P_SBSD_EMP_NAME
        /// </summary>
        [DataMember(Order = 1)]
        public string EmployeeName { get; set; }

        /// <summary>
        /// تاريخ الميلاد
        /// P_SBSD_EMP_BDATE
        /// </summary>
        [DataMember(Order = 2)]
        public string EmployeeBirthDate { get; set; }

        /// <summary>
        /// رقم الهوية
        /// P_SBSD_EMP_ID
        /// </summary>
        [DataMember(Order = 3)]
        public long EmployeeNationalId { get; set; }

        /// <summary>
        /// تاريخ التعيين
        /// P_SBSD_EMP_HIRE_DT
        /// </summary>
        [DataMember(Order = 4)]
        public string EmployeeHireDate { get; set; }

        /// <summary>
        /// المؤهل
        /// P_SBSD_EMP_QUALIF_CD
        /// </summary>
        [DataMember(Order = 5)]
        public int EmployeeQualification { get; set; }

        /// <summary>
        /// الخبرات
        /// P_SBSD_EMP_EXPR_PRD_CD
        /// </summary>
        [DataMember(Order = 6)]
        public string EmployeeSpecialistCD { get; set; }

        /// <summary>
        /// أي امتيازات أخرى
        /// P_SBSD_EMP_PRIVILEGES
        /// </summary>
        [DataMember(Order = 7)]
        public string OtherPrivileges { get; set; }

        /// <summary>
        /// موافقة أعضاء مجلس الإدارة على التعيين
        /// P_SBSD_EMP_HIRE_BOD_AGREE_FLG / P_SBSD_EMP_CONTRACT_FLG
        /// </summary>
        [DataMember(Order = 8)]
        public int AppointmentBoardApproval { get; set; }

        /// <summary>
        /// عقد العمل
        /// P_SBSD_EMP_CONTRACT_FLG
        /// </summary>
        [DataMember(Order = 9)]
        public int IsThereJobContract { get; set; }


    }
}
