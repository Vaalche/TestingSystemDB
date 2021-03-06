﻿using System.Linq;
using TestingSystemDB;

namespace KursovProektPS
{
    public class AuthenticatorVM
    {
        public BaseVM Authenticate(LoginModel loginInfo)
        {
            loginInfo.Password = BoundPasswordBox.Password;
            IRepository<User> userRepository = RepositoryFactory.Get<User>();
            User userInDB = null;
            using (var ctx = new TestingSystemModel())
            {
                userInDB = userRepository.FindBy(user => user.nickname.Equals(loginInfo.Username), ctx).FirstOrDefault();
            }
            if (userInDB != null && userInDB.password.Equals(loginInfo.Password))
            {
                MainWindowVM.CurrentUser = userInDB;
                BaseVM result = new TestSetupVM();
                result.ResourceName = "setup";
                return result;
            }
            else
            {
                BaseVM result = new LoginVM(loginInfo, "Проблем с автентикацията на потребителя!!!");
                result.ResourceName = "login";
                return result;
            }
        }
    }
}
