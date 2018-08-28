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
        [DataMember(Order = 0)]
        public string StageDate { get; set; }

        /// <summary>
        /// تكلفة المرحلة
        /// STG_COST
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 1)]
        public decimal StageCost { get; set; }

        /// <summary>
        /// ملاحظات
        /// STG_NOTE
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public string Notes { get; set; }





    }
}
