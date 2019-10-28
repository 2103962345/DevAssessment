using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevAssessment.Auth.Model;

namespace DevAssessment.Auth.MockServices
{
    public class LoginManager : ILoginManager
    {
        public async Task<bool> LoginUser(User user)
        {
            //fake delay for 0.1 second..
            await Task.Delay(100);

            if (user.UserName == "abdul@gmail.com" && user.Password == "12345")
                return true;
            else if (user.UserName == "ali@gmail.com" && user.Password == "12345")
                return true;
            else
                return false;
        }

        public async Task<bool> IsAdmin(string userName)
        {
            //fake delay for 0.1 second..
            await Task.Delay(100);

            if (userName == "abdul@gmail.com")
                return true;
            else
                return false;
        }
    }
}
