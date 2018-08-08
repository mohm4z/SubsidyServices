using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Charities
{
    /// <summary>
    /// بيانات الجمعية الخيرية
    /// </summary>
    [DataContract(Namespace = "CharityInfo")]
    public class CharityInfo
    {
        /// <summary>
        /// رقم ترخيص الجهة 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string LicenseNumber { get; set; }

        /// <summary>
        /// نوع الجهة 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int CharityType { get; set; }

        /// <summary>
        /// اسم مركز التنمي
        /// </summary>
        [DataMember]
        public string DevelopmentCenterName { get; set; }

        /// <summary>
        /// اسم الجهه
        /// </summary>
        [DataMember]
        public string CharityName { get; set; }

        /// <summary>
        /// تاريخ الترخيص
        /// </summary>
        [DataMember]
        public string LicenseDate { get; set; }

        /// <summary>
        /// منطقة الخدمات
        /// </summary>
        [DataMember]
        public string ServiceArea { get; set; }

        /// <summary>
        /// اسم البنك
        /// </summary>
        [DataMember]
        public string BankName { get; set; }

        /// <summary>
        /// رقم الحساب البنكي - ايبان
        /// </summary>
        [DataMember]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// تصنيف الجهه
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string CharityClassification { get; set; }

        /// <summary>
        /// رقم الحاسب 700
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string AccountNumber700 { get; set; }

        [DataMember]
        public RequestResult RequestResult { get; set; }


    }
}
