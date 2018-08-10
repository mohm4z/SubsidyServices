using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;
using Models.Common;

namespace Models.Cooperative
{
    [DataContract(Namespace = "OperationInfo")]
    public class OperationInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// هل توجد دراسة جدوى اقتصادية للمشروع
        /// ECONOMIC_FEASIBILITY_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public int IsThereFeasibilityStudy { get; set; }
    }
}
