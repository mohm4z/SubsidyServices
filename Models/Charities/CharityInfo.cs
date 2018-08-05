using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Charities
{
    [DataContract]
    public class CharityInfo
    {
        //[DataMember(EmitDefaultValue = false, IsRequired = true)]
        [DataMember]
        public string DevelopmentCenterName { get; set; }

        [DataMember]
        public string CharityName { get; set; }

        [DataMember]
        public string RegistrationDate { get; set; }

        [DataMember]
        public string ServiceArea { get; set; }

        [DataMember]
        public string BankName { get; set; }

        [DataMember]
        public long BankAccountNumber { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string CharityClassification { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long AccountNumber700 { get; set; }

        [DataMember]
        public RequestResult RequestResult { get; set; }

    }
}
