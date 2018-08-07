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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICharityCommonService" in both code and config file together.
    [ServiceContract(
       ConfigurationName = "mlsd.gov.sa",
       Namespace = "http://mlsd.gov.sa",
       Name = "mlsd"
       )]
    public interface ICharityCommonService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CharityInfo GetCharityInfo(
            long LicenseNumber,
            int CharityType
            );


        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CharityGoals GetCharityGoals(
            long LicenseNumber,
            int CharityType
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CharityFiles GetCharityFiles(
            long SubsidyCode
            );


        //[OperationContract]
        //[FaultContract(typeof(ValidationFault))]
        //RequestResult InsertAttachment(
        //   long RequestId,
        //   int FileNumber,
        //   string FilePath,
        //   long CommissionerNumber
        //   );
    }
}
