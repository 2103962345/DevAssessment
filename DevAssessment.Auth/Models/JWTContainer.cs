using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DevAssessment.Auth.Model
{
    public class JWTContainer
    {

        // expiry in days = 7.
        public int ExpireMinutes { get; set; } = 10080;

        //the secret key should be imported from server/cloud configurations
        public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ=="; 
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
    }
}
