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
    /// بيانات الجمعية الخيرية
    /// </summary>
    [DataContract(Namespace = "AgencyInfo")]
    public class AgencyInfo
    {
        /// <summary>
        /// رقم ترخيص الجهة 
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string LicenseNumber { get; set; }

        /// <summary>
        /// نوع الجهة 
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public int CharityType { get; set; }

        /// <summary>
        /// اسم مركز التنمي
        /// </summary>
        [DataMember(Order = 2)]
        public string DevelopmentCenterName { get; set; }

        /// <summary>
        /// اسم الجهه
        /// </summary>
        [DataMember(Order = 3)]
        public string CharityName { get; set; }

        /// <summary>
        /// تاريخ الترخيص
        /// </summary>
        [DataMember(Order = 4)]
        public string LicenseDate { get; set; }

        /// <summary>
        /// منطقة الخدمات
        /// </summary>
        [DataMember(Order = 5)]
        public string ServiceArea { get; set; }

        /// <summary>
        /// اسم البنك
        /// </summary>
        [DataMember(Order = 6)]
        public string BankName { get; set; }

        /// <summary>
        /// رقم الحساب البنكي - ايبان
        /// </summary>
        [DataMember(Order = 7)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// تصنيف الجهه
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string CharityClassification { get; set; }

        /// <summary>
        /// رقم الحاسب 700
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string AccountNumber700 { get; set; }

        [DataMember(Order = 10)]
        public RequestResult RequestResult { get; set; }


    }
}
