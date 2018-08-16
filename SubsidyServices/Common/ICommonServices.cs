using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonServices" in both code and config file together.
    [ServiceContract(
       ConfigurationName = "mlsd.ServiceContractConfig",
       Namespace = "http://mlsd.gov.sa"
       )]
    public interface ICommonServices
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<LookupTable> GetLookup(
            string ApplicationCode,
            int TabNumber
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<LookupTable> GetSubLookup(
            string ApplicationCode,
            int TabNumber,
            int SubTabNumber
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AgencyInfo GetAgencyInfo(
            int AgencyType,
            long AgencyLicenseNumber
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AgencyGoals GetAgencyGoals(
            int AgencyType,
            long AgencyLicenseNumber
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AgencyFiles GetAgencyFiles(
            long SubsidyCode
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestPreviousStatus CheckPreviousRequestsStatus(
            int CheckType,
            int AgencyType,
            long AgencyLicenseNumber,
            int SubsidyCode
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<FinancialYears> GetFinancialYears(
            int AgencyType
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        string NumberToText(
            decimal Number
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<Request> GetPreviousRequests(
            int AgencyType,
            long AgencyLicenseNumber,
            string SubsidyCode,
            string  RequestsStatusId
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<Subsidy> CheckSubsidyInfo(
           int? AgencyType,
           int? SubsidyCode
           );
    }
}
