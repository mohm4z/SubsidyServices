﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.SpParameters
{
    [DataContract]
    public class SpInPuts
    {
        [DataMember]
        public string KEY { get; set; }

        [DataMember]
        public object VALUE { get; set; }
    }
}
