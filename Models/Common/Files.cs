using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Models.Common
{
    /// <summary>
    /// الملفات
    /// </summary>
    [DataContract(Namespace = "Files")]
    public class Files
    {
        /// <summary>
        /// رقم الملف
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// إسم او مسار الملف
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 1)]
        public string Path { get; set; }
    }
}
