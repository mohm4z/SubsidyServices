﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    /// <summary>
    /// بيانات خدمة التأسيسية للجمعيات التعاونية
    /// </summary>
    [DataContract(Namespace = "FoundationInfo")]
    public class FoundationInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// راس مال الجمعية بداية التأسيس
        /// P_ESTBLSH_CAPITAL
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 2)]
        public decimal CompanyCapitalInBeginning { get; set; }
    }
}
