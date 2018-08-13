using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;
using Models.HandleFault;

namespace SubsidyServices.Charities
{
    [ServiceContract(
       ConfigurationName = "mlsd.ServiceContractConfig",
       Namespace = "http://mlsd.gov.sa"
       )]
    public interface IFoundationSubsidy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CharityType"></param>
        /// <param name="LicenseNumber"></param>
        /// <param name="ChairmanBoardMobileNumber"></param>
        /// <param name="ChairmanBoardName"></param>
        /// <param name="CommissionerNumber"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult InsertFoundationSubsidy(
           CheckedData CheckedData,
           string ChairmanBoardMobileNumber,
           string ChairmanBoardName
           //List<Files> Files
           );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        RequestResult UpdateFoundationSubsidy(
           long RequestId,
           CheckedData CheckedData,
           string ChairmanBoardMobileNumber,
           string ChairmanBoardName
           );



    }
}
