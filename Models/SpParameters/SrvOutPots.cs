using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.SpParameters
{
    [DataContract]
    public class SrvOutPots
    {
        [DataMember]
        public string KEY { get; set; }

        [DataMember]
        public string VALUE { get; set; }
    }
}
