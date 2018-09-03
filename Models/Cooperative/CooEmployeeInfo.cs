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
    [DataContract(Namespace = "AccountantInfo")]
    public class CooEmployeeInfo
    {
        /// <summary>
        /// اسم المدير
        /// P_SBSD_EMP_NAME
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 150)]
        [DataMember(Order = 0)]
        public string EmployeeName { get; set; }

        /// <summary>
        /// تاريخ الميلاد
        /// P_SBSD_EMP_BDATE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 8)]
        [DataMember(Order = 1)]
        public int EmployeeBirthDate { get; set; }

        /// <summary>
        /// رقم الهوية
        /// P_SBSD_EMP_ID
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 2)]
        public long EmployeeNationalId { get; set; }

        /// <summary>
        /// تاريخ التعيين
        /// P_SBSD_EMP_HIRE_DT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 8)]
        [DataMember(Order = 3)]
        public int EmployeeHireDate { get; set; }

        /// <summary>
        /// المؤهل
        /// P_SBSD_EMP_QUALIF_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2)]
        [DataMember(Order = 4)]
        public int EmployeeQualification { get; set; }

        /// <summary>
        /// الخبرات
        /// P_SBSD_EMP_EXPR_PRD_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2)]
        [DataMember(Order = 5)]
        public int EmployeeSpecialistCD { get; set; }

        /// <summary>
        /// أي امتيازات أخرى
        /// P_SBSD_EMP_PRIVILEGES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 6)]
        public string OtherPrivileges { get; set; }

        /// <summary>
        /// موافقة أعضاء مجلس الإدارة على التعيين
        /// P_SBSD_EMP_HIRE_BOD_AGREE_FLG / P_SBSD_EMP_CONTRACT_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 7)]
        public int AppointmentBoardApproval { get; set; }

        /// <summary>
        /// عقد العمل
        /// P_SBSD_EMP_CONTRACT_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 8)]
        public int IsThereJobContract { get; set; }


    }
}
