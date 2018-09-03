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
        [DataMember(Order = 0, IsRequired = true)]
        public CheckedData CheckedData { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public ManagersInfo ManagersInfo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public MeetingInfo MeetingInfo { get; set; }

        /// <summary>
        /// هل تمتلك الجمعية عدد ثلاث آليات ميكانيكية جاهـزة للاستخدام؟
        /// P_HAVE_3_MACHINES_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 3)]
        public int IsAgencyHaveThreeMachinesReady { get; set; }

        /// <summary>
        /// العاملين على الآليات
        /// 1  SAUDI
        /// 2  NON SAUDI
        /// 3  BOTH
        /// P_MACHINES_WORKERS_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 4)]
        public int WorkersOnMachines { get; set; }

        /// <summary>
        /// رواتب الموظفين السعوديين العاملين على الاليات
        /// P_SAUDI_WORKERS_SALARIES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 5)]
        public decimal SaudisSalaries { get; set; }

        /// <summary>
        /// عدد الموظفين السعوديين العاملين على الاليات
        /// P_SAUDI_WORKERS_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 4)]
        [DataMember(Order = 6)]
        public int SaudisCount { get; set; }

        /// <summary>
        /// رواتب الموظفين غير السعوديين العاملين على الآليات
        /// P_NON_SAUDI_WORKERS_SALARIES
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 11)]
        [DataMember(Order = 7)]
        public decimal NonSaudisSalaries { get; set; }

        /// <summary>
        /// عدد الموظفين غير السعوديين العاملين على الآليات
        /// P_NON_SAUDI_WORKERS_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 4)]
        [DataMember(Order = 8)]
        public int NonSaudisCount { get; set; }

        /// <summary>
        /// عدد السيارات و الآليات التي تمتلكها المجموعة
        /// P_MACHINES_COUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 4)]
        [DataMember(Order = 9)]
        public int OwnedVehiclesCount { get; set; }

        /// <summary>
        /// هل يتوافق مسمى وظيفة العامل على الآلة مع طبيعة عمله في العقد؟
        /// P_JOB_CONTRACT_CMTBL_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 10)]
        public int IsJobCompatibleWithContract { get; set; }

        /// <summary>
        /// هل توجد شهادة من مجلس الإدارة بمدة عمل الآليات وانقطاعها خلال السنة في نفس منطقة 
        /// P_BOD_MACHINES_CERTF_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 11)]
        public int IsThereJobCertificateForMachines { get; set; }

        /// <summary>
        /// هل توجد شهادة من الجهه المختصه تؤكد صلاحية الأليات للعمل
        /// P_SUPPLIER_MACHINES_CERTF_FLG
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 1)]
        [DataMember(Order = 12)]
        public int IsThereCertificateAssureMechanismsValid { get; set; }

        /// <summary>
        /// مبلغ الاعانة المطلوبة من الوزارة
        /// P_REQUEST_AMOUNT
        /// </summary>
        [ItsRequired]
        [Length(MaxLength = 13)]
        [DataMember(Order = 13)]
        public decimal RequiredSubsidy { get; set; }
    }
}
