using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Charities
{
    [DataContract]
    public class EmployeeInfo
    {
        /// <summary>
        /// معلومات الموظف 
        /// </summary>
        [DataMember]
        public int CharityType { get; set; }

        [DataMember]
        public long LicenseNumber { get; set; }

        [DataMember]
        public int SubsidyType { get; set; }

        [DataMember]
        public string ChairmanBoardName { get; set; }

        [DataMember]
        public long ChairmanBoardMobileNumber { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public string EmployeeHireDate { get; set; }

        [DataMember]
        public long EmployeeNationalId { get; set; }

        [DataMember]
        public string EmployeeBirthDate { get; set; }

        [DataMember]
        public string EmployeeNationality { get; set; }

        [DataMember]
        public int EmployeeQualification { get; set; }

        [DataMember]
        public string EmployeeSpecialist { get; set; }

        [DataMember]
        public int EmployeeSpecialistCD { get; set; }

        [DataMember]
        public int EmployeeExpertise { get; set; }

        [DataMember]
        public decimal EmployeeSalary { get; set; }

        [DataMember]
        public decimal EmployeeRentAmount { get; set; }

        [DataMember]
        public long CommissionerNumber { get; set; }

    }

}
