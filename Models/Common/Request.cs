using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Common
{
    [DataContract(Namespace = "Request")]
    public class Request
    {
        [DataMember(Order = 0)]
        public string AgencyType { get; set; }

        [DataMember(Order = 1)]
        public string AgencyLicenseNumber { get; set; }

        [DataMember(Order = 2)]
        public string RequestId { get; set; }

        [DataMember(Order = 3)]
        public string RequestDate { get; set; }

        [DataMember(Order = 4)]
        public string RequestsStatusId { get; set; }

        [DataMember(Order = 5)]
        public string RequestsStatusName { get; set; }

        [DataMember(Order = 6)]
        public string DevelopmentCenterNumber { get; set; }

        [DataMember(Order = 7)]
        public string DevelopmentCenterName { get; set; }

        [DataMember(Order = 8)]
        public string SubsidyCode { get; set; }

        [DataMember(Order = 9)]
        public string SubsidyName { get; set; }
    }
}
