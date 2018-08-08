using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Common
{
    [DataContract]
    public class AgencyFiles
    {
        [DataMember]
        public IEnumerable<Files> Files { get; set; }

        [DataMember]
        public RequestResult RequestResult { get; set; }


    }
}
