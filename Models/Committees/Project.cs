using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Models.Common;

namespace Models.Committees
{
    /// <summary>
    /// بيانات المشروع
    /// </summary>
    [DataContract(Namespace = "Project")]
    public class Project
    {
        /// <summary>
        /// المساهمة الحكومية المقترحة
        /// PROG_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 0)]
        public string ProposedGovernmentContribution { get; set; }



    }
}
