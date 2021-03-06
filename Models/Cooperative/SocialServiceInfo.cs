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
    /// بيانات خدمة اعانة خدمات جمعيات
    /// </summary>
    [DataContract(Namespace = "SocialServiceInfo")]
    public class SocialServiceInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// المبلغ الذي تم صرفه على الخدمات الاجتماعية رقماً
        /// P_SOCIALS_SPENT_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 12)]
        [DataMember(Order = 2)]
        public decimal AmountForSocialServicetAsNumber { get; set; }

        /// <summary>
        /// الجهات التي تم الصرف عليها
        /// P_SOCIALS_SPENT_ON
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2000)]
        [DataMember(Order = 3)]
        public string AgenciesDisbursedOnIt { get; set; }

        /// <summary>
        /// هل يوجد محضر اجتماع مجلس الإدارة بالموافقة على الصرف من بند الخدمات الاجتماعية
        /// P_SOCIALS_BOD_AGREE_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 4)]
        public int IsThereApprovingDisbursementOfSociaServices { get; set; }

        /// <summary>
        /// هل يوجد بيان بالجهات التي تم الصرف عليها ومبالغها معتمد من مجلس الإدارة ومصدقا من الجهة المشرفة بالمنطقة
        /// P_SOCIALS_SPENT_LETTER_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 5)]
        public int IsThereStatementOfDisbursedAgenciesAndCertified { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 6)]
        public decimal RequiredSubsidy { get; set; }
    }
}
