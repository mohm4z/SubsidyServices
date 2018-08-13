using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubsidyServices.Committees
{
    [ServiceContract]
    public interface ICommitteeServices
    {
        [OperationContract]
        void DoWork();
    }
}
