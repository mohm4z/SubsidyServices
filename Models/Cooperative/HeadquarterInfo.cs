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
    /// معلومات بناء مقر للجمعية
    /// </summary>
    [DataContract(Namespace = "HeadquarterInfo")]
    public class HeadquarterInfo
    {
        [DataMember(Order = 0)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1)]
        public ManagersInfo ManagersInfo { get; set; }

        /// <summary>
        /// هل سبق دعم الجمعية بإعانة انشائية؟ 
        /// P_PARTNERS_FLAG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 2)]
        public int IsAgencyHaveSupportedBeforeInRebuild { get; set; }

        /// <summary>
        /// المبلغ
        /// P_PARTNERS_FUND_SUPPORT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 3)]
        public decimal AmountOfSupported { get; set; }

        /// <summary>
        /// الجهة الداعمة
        /// P_PARTNERS_LIST
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 4)]
        public string AgencyOfSupported { get; set; }

        /// <summary>
        /// هل تملك الجمعية صك للأرض المراد إقامة المبنى عليها على ان تكون صالحة للبناء عليها
        /// P_LAND_INSTRUMENT_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 5)]
        public int IsAgencyHaveLandToBuild { get; set; }

        /// <summary>
        /// المبلغ المرصود من قبل الجمعية للمشروع رقماً
        /// P_PROJ_REG_SHARE_AMNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 6)]
        public decimal AmountForProjectAsNumber { get; set; }

        /// <summary>
        /// المبلغ المصروف على المشروع الظاهر في الميزانية
        /// P_PROJ_EXPEND_BAL_AMNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 7)]
        public decimal ExpendedOnProjectInBudget { get; set; }
    }
}
