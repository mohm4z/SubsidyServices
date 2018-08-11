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
    /// بيانات خدمة اعانة خدمات جمعيات
    /// </summary>
    [DataContract(Namespace = "SocialServiceInfo")]
    public class SocialServiceInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2)]
        public MeetingInfo MeetingInfo { get; set; }




        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 12)]
        public decimal RequiredSubsidy { get; set; }
    }
}
