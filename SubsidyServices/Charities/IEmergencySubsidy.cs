﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using Models.Charities;
using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Charities
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmergencySubsidy" in both code and config file together.
    [ServiceContract(
       ConfigurationName = "mlsd.ServiceContractConfig",
       Namespace = "http://mlsd.gov.sa"
       )]
    public interface IEmergencySubsidy
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertEmergencySubsidy(
           EmergencyInfo EmergencyInfo,
           List<Files> Files
           );
    }
}
