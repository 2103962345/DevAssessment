using DevAssessment.Auth.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevAssessment.Auth.MockServices
{
    public interface ILoginManager
    {
        Task<bool> LoginUser(User user);
    }
}
