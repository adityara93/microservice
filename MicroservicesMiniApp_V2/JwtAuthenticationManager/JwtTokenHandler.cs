using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "S4mpleApp_Ind0nesi4";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccounts;
        public JwtTokenHandler()
        {
            _userAccounts = new List<UserAccount>
            {
                new UserAccount{ Username ="admin", Password="admin123",Role="Administrator"},
                new UserAccount{ Username ="user01", Password="user1234",Role="User"},
            };
        }

        public AuthenticationResponse GenerateJwtToken(AuthenticationRequest authRequest)
        {
            if (string.IsNullOrWhiteSpace(authRequest.Username) || string.IsNullOrWhiteSpace(authRequest.Password))
                return null;

            /** Validation **/
            var userAccount = _userAccounts.Where(x => x.Username == authRequest.Username && x.Password == authRequest.Password).FirstOrDefault();
            if (userAccount == null) return null;

            var tokenExpiredTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, authRequest.Username),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiredTimeStamp,
                SigningCredentials = signinCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                Username = userAccount.Username,
                ExpiredIn = (int)tokenExpiredTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
            };
        }
    }
}
