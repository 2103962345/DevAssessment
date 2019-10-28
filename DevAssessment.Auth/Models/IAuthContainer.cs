using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DevAssessment.Auth.Model
{
    public class IAuthContainer
    {
        public string SecretKey { get; set; }
        public string SecurityAlgorithm { get; set; }
        public int ExpireMinutes { get; set; }

        public Claim[] Claims { get; set; }
    }
}
