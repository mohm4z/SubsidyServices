﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace Models.Common
{
    /// <summary>
    /// أهداف الجمعية
    /// </summary>
    [DataContract(Namespace = "Goals")]
    public class Goals
    {
        //[DataMember]
        //public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

    }
   
}
