using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Charities
{
    [DataContract]
    public class EmergencyInfo
    {
        [DataMember]
        public int CharityType { get; set; }

        [DataMember]
        public long LicenseNumber { get; set; }

        [DataMember]
        public int SubsidyType { get; set; }

        [DataMember]
        public int BeneficiariesCount { get; set; }

        [DataMember]
        public int VolunteersCount { get; set; }

        [DataMember]
        public int SaudiEmployeesCount { get; set; }

        [DataMember]
        public int NonSaudiEmployeesCount { get; set; }

        [DataMember]
        public bool IsbudgetIssued { get; set; }

        [DataMember]
        public bool IsBoardOfDirectorsMeetingsRegular { get; set; }

        [DataMember]
        public bool IsGeneralAssemblyMeetingsRegular { get; set; }

        [DataMember]
        public bool GeneralAssemblyIrregularityMeetingReason { get; set; }

        [DataMember]
        public decimal TotalExpensesAdministrativePreviousYear { get; set; }

        [DataMember]
        public decimal TotalExpensesForActivitiesPreviousYear { get; set; }

        [DataMember]
        public int ProgramsImplementedPreviousYearCount { get; set; }

        [DataMember]
        public string GovernmentEvaluationResult { get; set; }

        [DataMember]
        public decimal BriefAboutEmergencyAssembly { get; set; }

        [DataMember]
        public string Causes { get; set; }

        [DataMember]
        public string ActionsTaken { get; set; }

        [DataMember]
        public bool AreTherePartners { get; set; }

        [DataMember]
        public string PartnerNames { get; set; }

        [DataMember]
        public decimal TotalPartnerSupport { get; set; }

        [DataMember]
        public decimal BankBalance { get; set; }

        [DataMember]
        public string RequiredSubsidy { get; set; }

        [DataMember]
        public long CommissionerNumber { get; set; }
    }
}
