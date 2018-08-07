using System;
using System.ServiceModel;


namespace SubsidyServices.App_Code.ServiceValidation
{
    public class UserNamePassValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "mm" && password == "mm"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}