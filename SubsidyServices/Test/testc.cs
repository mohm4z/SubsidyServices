using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;


namespace SubsidyServices.Test
{
    [DataContract]
    public class testc
    {
        [DataMember(
            IsRequired = false,
            EmitDefaultValue = true
            )]
        public int c1;


        [DataMember(
            IsRequired = true
            )]
        public int c2 = 0;
    }
}