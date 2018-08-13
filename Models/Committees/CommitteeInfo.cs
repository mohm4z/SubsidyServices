using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Committees
{
    [DataContract(Namespace = "CommitteeInfo")]
    public class CommitteeInfo
    {
        /// <summary>
        /// اسم مركز التنمية
        /// P_BRN_NAME
        /// </summary>
        [DataMember(Order = 2)]
        public string DevelopmentCenterName { get; set; }

        /// <summary>
        /// رقم مركز التنمية
        /// P_BRN_NO
        /// </summary>
        [DataMember(Order = 2)]
        public string DevelopmentCenterNumber { get; set; }

        /// <summary>
        /// اسم اللجنة
        /// P_REG_NAME
        /// </summary>
        [DataMember(Order = 3)]
        public string CommitteeName { get; set; }

        /// <summary>
        /// تصنيف اللجنة
        /// P_CLASS_CD
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string CommitteeClassification { get; set; }

        /// <summary>
        /// رقم الحساب البنكي - ايبان
        /// P_IBAN_NO  
        /// </summary>
        [DataMember(Order = 7)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// اسم البنك
        /// P_BANK_NAME       
        /// </summary>
        [DataMember(Order = 6)]
        public string BankName { get; set; }

        /// <summary>
        /// رصيد اللجنة
        /// P_ACCOUNT_BALANCE       
        /// </summary>
        [DataMember(Order = 6)]
        public string AccountBalance { get; set; }

        [DataMember(Order = 10)]
        public RequestResult RequestResult { get; set; }
    }
}
