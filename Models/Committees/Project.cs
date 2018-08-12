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
    class Project
    {
       

        /// <summary>
        /// ظهرت رواتب المحاسب منفصلة عن رواتب الموظفين في الميزانية
        /// P_BALSHT_SAL_SPRT_FLG
        /// </summary>
        [ItsRequired]
        [DataMember(Order = 0)]
        public int AccountantSalarySeparateInTheBudget { get; set; }



    }
}
