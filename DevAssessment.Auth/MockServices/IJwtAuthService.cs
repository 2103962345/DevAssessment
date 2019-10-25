using DevAssessment.Auth.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DevAssessment.Auth.MockServices
{
    public interface IJwtAuthService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);
        string GenerateToken(JWTContainer model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
