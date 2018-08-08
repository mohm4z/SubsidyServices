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
        [DataMember(Order = 0)]
        public int CharityType { get; set; }

        [DataMember(Order = 1)]
        public long LicenseNumber { get; set; }

        [DataMember(Order = 2)]
        public int SubsidyType { get; set; }

        [DataMember(Order = 3)]
        public string ChairmanBoardName { get; set; }

        [DataMember(Order = 4)]
        public long ChairmanBoardMobileNumber { get; set; }

        [DataMember(Order = 5)]
        public string EmployeeName { get; set; }

        [DataMember(Order = 6)]
        public string EmployeeHireDate { get; set; }

        [DataMember(Order = 7)]
        public long EmployeeNationalId { get; set; }

        [DataMember(Order = 8)]
        public string EmployeeBirthDate { get; set; }

        [DataMember(Order = 9)]
        public string EmployeeNationality { get; set; }

        [DataMember(Order = 10)]
        public string EmployeeQualification { get; set; }

        [DataMember(Order = 11)]
        public string EmployeeSpecialist { get; set; }

        [DataMember(Order = 12)]
        public string EmployeeSpecialistCD { get; set; }

        [DataMember(Order = 13)]
        public int EmployeeExpertise { get; set; }

        [DataMember(Order = 14)]
        public decimal EmployeeSalary { get; set; }

        [DataMember(Order = 15)]
        public decimal EmployeeRentAmount { get; set; }

        [DataMember(Order = 16)]
        public long CommissionerNumber { get; set; }

    }

}
