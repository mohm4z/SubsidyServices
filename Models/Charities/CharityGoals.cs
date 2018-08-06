using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Charities
{
    [DataContract]
    public class CharityGoals
    {
        [DataMember]
        public IEnumerable<Goals> Goals { get; set; }

        [DataMember]
        public RequestResult RequestResult { get; set; }


    }


}
