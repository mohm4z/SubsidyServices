using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;


namespace SubsidyServices.App_Code.ServiceValidation
{
    [ServiceContract]
    public interface ISecurityContract
    {
        [OperationContract]
        string GetServertime();
    }

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SecurityContract : ISecurityContract
    {
        public string GetServertime()
        {
            return DateTime.Now.ToString();
        }
    }
}
