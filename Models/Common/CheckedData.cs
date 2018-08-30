using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Reflection;

namespace Models.Common
{
    /// <summary>
    /// البيانات التي سيتم فحصها لتأكد من أن المستخم له صلاحيات على هذه الخدمة
    /// </summary>
    [DataContract(Namespace = "CheckedData")]
    public class CheckedData
    {
        /// <summary>
        /// نوع الجهه
        /// P_REG_TYPE_CODE  
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2)]
        [DataMember(Order = 0)]
        public int AgencyType { get; set; }

        /// <summary>
        /// رقم ترخيص الجهه
        /// P_REG_ID / P_SOC_REG_NO
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 7)]
        [DataMember(Order = 1)]
        public int AgencyLicenseNumber { get; set; }

        /// <summary>
        /// رقم هوية المفوض 
        /// P_LOGIN_ID
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 10)]
        [DataMember(Order = 2)]
        public string CommissionerNumber { get; set; }

    }
}
