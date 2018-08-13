using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using Models.Common;
using Models.HandleFault;
using Models.Committees;


namespace SubsidyServices.Committees
{
    [ServiceContract(
       ConfigurationName = "mlsd.ServiceContractConfig",
       Namespace = "http://mlsd.gov.sa"
       )]
    public interface ICommonServices
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CommitteeInfo GetCommitteeInfo(
            int AgencyType,
            long AgencyLicenseNumber
            );
    }
}
