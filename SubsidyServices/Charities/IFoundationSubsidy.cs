using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFoundationSubsidy" in both code and config file together.
    [ServiceContract(
       ConfigurationName = "mlsd.gov.sa",
       Namespace = "http://mlsd.gov.sa",
       Name = "mlsd"
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
           int CharityType,
           long LicenseNumber,
           long ChairmanBoardMobileNumber,
           string ChairmanBoardName,
           long CommissionerNumber,
           List<Files> Files
           );


        
    }
}
