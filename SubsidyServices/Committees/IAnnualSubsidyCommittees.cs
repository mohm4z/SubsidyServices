using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Committees;
using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Committees
{
    [ServiceContract(
       ConfigurationName = "mlsd.ServiceContractConfig",
       Namespace = "http://mlsd.gov.sa"
       )]
    public interface IAnnualSubsidyCommittees
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertAnnualSubsidyCommittees(
             CommitteeRequestInfo CommitteeRequestInfo,
             List<Files> Files
             );
    }
}
