﻿using System;
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
       ConfigurationName = "mlsd.gov.sa",
       Namespace = "http://mlsd.gov.sa",
       Name = "mlsd"
       )]
    public interface ICommonServices
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<LookupTable> GetLookup(
            string ApplicationCode,
            int TabNumber
          );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LicenseNumber"></param>
        /// <param name="CharityType"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AgencyInfo GetAgencyInfo(
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
        AgencyGoals GetAgencyGoals(
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
        AgencyFiles GetAgencyFiles(
            long SubsidyCode
            );
    }
}
