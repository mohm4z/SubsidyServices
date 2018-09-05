using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;
using Models.Common;

namespace Models.Common
{
    /// <summary>
    /// هل للمفوظ صلاحية على الخدمة
    /// </summary>
    [DataContract(Namespace = "IsDelegatorAuthorizedResult")]
    public class IsDelegatorAuthorizedResult
    {
        /// <summary>
        /// P_BRN_NAME
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 0)]
        public string BRN_NAME { get; set; }

        /// <summary>
        /// P_DLGT_NAME
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 1)]
        public string DLGT_NAME { get; set; }

        /// <summary>
        /// MESSAGE_CODE >> P_RESULT_CODE
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 2)]
        public string MESSAGE_CODE { get; set; }

        /// <summary>
        /// MESSAGE_DESC >> P_RESULT_TEXT
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 3)]
        public string MESSAGE_DESC { get; set; }

        /// <summary>
        /// P_MOBILE_NO
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 4)]
        public string MOBILE_NO { get; set; }

        /// <summary>
        /// P_REG_DT
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 5)]
        public string REG_DT { get; set; }

        /// <summary>
        /// P_SOC_NAME
        /// </summary>
        [DataMember(EmitDefaultValue = true, Order = 6)]
        public string SOC_NAME { get; set; }
    }
}
