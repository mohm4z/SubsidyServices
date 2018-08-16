using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;
using Models.Common;


namespace SubsidyServices.Test
{
    [DataContract]
    public class testc
    {
        [DataMember(
            IsRequired = false,
            EmitDefaultValue = true
            )]
        public int C1;


        [ItsRequired]
        [DataMember(IsRequired = true)]
        public int C2 = 0;

        [ItsRequired]
        [DtoProperty(1)]
        [DataMember(IsRequired = true)]
        public int C3 { get; set; }
    }
}