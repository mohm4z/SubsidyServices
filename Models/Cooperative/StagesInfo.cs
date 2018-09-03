using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    /// <summary>
    /// مراحل طلب بناء مقر رئيسي
    /// </summary>
    [DataContract(Namespace = "StagesInfo")]
    public class StagesInfo
    {
        /// <summary>
        /// تاريخ المرحلة
        /// STG_DT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 8)]
        [DataMember(Order = 0)]
        public string StageDate { get; set; }

        /// <summary>
        /// تكلفة المرحلة
        /// STG_COST
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12.2)]
        [DataMember(Order = 1)]
        public decimal StageCost { get; set; }

        /// <summary>
        /// ملاحظات
        /// STG_NOTE
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 2)]
        public string Notes { get; set; }





    }
}
