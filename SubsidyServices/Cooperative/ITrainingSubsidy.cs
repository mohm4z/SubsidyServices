﻿using System;
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
    [ServiceContract(
       ConfigurationName = "mlsd.gov.sa",
       Namespace = "http://mlsd.gov.sa",
       Name = "mlsd"
       )]
    public interface ITrainingSubsidy
    {
        /// <summary>
     
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertTrainingSubsidy(
            TrainingInfo TrainingInfo,
            List<Files> Files
            );
    }
}
