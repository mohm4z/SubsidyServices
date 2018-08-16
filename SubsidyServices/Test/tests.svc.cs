using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Models.Common;


namespace SubsidyServices.Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "tests" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select tests.svc or tests.svc.cs at the Solution Explorer and start debugging.
    public class tests : Itests
    {
        public string DoWork(
            testc c
            )
        {

            DataValidation.IsEmptyOrDefault(c);
            DataValidation.TestMethod(c);

            return "NA";
        }
    }
}
