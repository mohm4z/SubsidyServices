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
    /// بيانات المدير
    /// </summary>
    [DataContract(Namespace = "AccountantInfo")]
    public class ManagerInfo
    {
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public CooEmployeeInfo CooEmployeeInfo { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// راتب السنه
        /// P_SBSD_EMP_YEAR_SALARY_CD
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 2)]
        [DataMember(Order = 4)]
        public int SalaryForWhichYear { get; set; }

        /// <summary>
        /// هل المدير متفرغ لأعمال الجمعية
        /// P_SBSD_EMP_FULLTIME_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 5)]
        public int IsDirectorDedicatedForJob { get; set; }

        /// <summary>
        /// مقدار الراتب:
        /// P_SBSD_EMP_SALARY
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 9)]
        [DataMember(Order = 6)]
        public decimal AnnualSalary { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 7)]
        public decimal RequiredSubsidy { get; set; }


    }
}
