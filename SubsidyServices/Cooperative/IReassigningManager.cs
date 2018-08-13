using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;
using Models.Cooperative;
using Models.HandleFault;

namespace SubsidyServices.Cooperative
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReassigningManager" in both code and config file together.
    [ServiceContract(
        ConfigurationName = "mlsd.ServiceContractConfig",
        Namespace = "http://mlsd.gov.sa"
        )]
    public interface IReassigningManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ManagerInfo"></param>
        /// <param name="Files"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertReassigningManager(
            ManagerInfo ManagerInfo,
            List<Files> Files
            );
    }
}
