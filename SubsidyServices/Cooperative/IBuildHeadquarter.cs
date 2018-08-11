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
    [ServiceContract(
       ConfigurationName = "mlsd.gov.sa",
       Namespace = "http://mlsd.gov.sa",
       Name = "mlsd"
       )]
    public interface IBuildHeadquarter
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="HeadquarterInfo"></param>
       /// <param name="Files"></param>
       /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertBuildHeadquarter(
            HeadquarterInfo HeadquarterInfo,
            List<StagesInfo> StagesInfo,
            List<Files> Files
            );
    }
}
