using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursovProektPS
{
    class AuthenticatorVM : BaseVM
    {
        public AuthenticatorVM()
        {
        }

        public BaseVM Authenticate(LoginModel loginInfo)
        {
            if (loginInfo.Username.Equals("admin") && loginInfo.Password.Equals("admin"))
            {
                return new TestSetupVM();
            }
            else
            {
                return new LoginVM(loginInfo);
            }
        }
    }
}
