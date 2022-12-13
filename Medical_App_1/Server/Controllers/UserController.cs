using Medical_App_1.Server.Services;
using Medical_App_1.Server.Services.UserManage.Interfaces;
using Medical_App_1.Shared.Models;
using Medical_App_1.Shared.Models.UserModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private IUserService _usercontext;
        public UserController( IConfiguration configuration, IUserService usercontext)
        {
          
            this._configuration = configuration;
            this._usercontext = usercontext;
        }
        //[HttpPost("registeruser")]
        //public async Task<ActionResult> RegisterUser(User user)
        //{
        //    //in this method you should only create a user record and not authenticate the user
        //    var emailAddressExists = _context.Users.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefault();
        //    if (emailAddressExists == null)
        //    {
        //        user.Password = Utility.Encrypt(user.Password);
        //        user.Source = "APPL";
        //        _context.Users.Add(user);
        //        await _context.SaveChangesAsync();
        //    }
        //    return Ok();
        //}

        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }
        //Migrating to JWT Authorization...
        private string GenerateJwtToken(User user)
        {
            //getting the secret key
            string secretKey = _configuration["JWTSettings:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            //create claims
            var claimEmail = new Claim(ClaimTypes.Email, user.EmailId);
            var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString());
            var claimRole = new Claim(ClaimTypes.Role, user.Role == null ? "" : user.Role);
            //create claimsIdentity
            var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimNameIdentifier, claimRole }, "serverAuth");

            // generate token that is valid for 7 days
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //creating a token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //returning the token back
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("authenticatejwt")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateJWT(AuthenticationRequest authenticationRequest)
        {
            string token = string.Empty;

            //checking if the user exists in the database
            authenticationRequest.password = Utility.Encrypt(authenticationRequest.password);
            User loggedInUser = await _usercontext.Authenticate(authenticationRequest.EmailId, authenticationRequest.password);
            if (loggedInUser != null)
            {
                //generating the token
                token = GenerateJwtToken(loggedInUser);
            }
            return await Task.FromResult(new AuthenticationResponse() { Token = token });
        }
        [HttpPost("getuserbyjwt")]
        public async Task<ActionResult<User>> GetUserByJWT([FromBody] string jwtToken)
        {
            try
            {
                //getting the secret key
                string secretKey = _configuration["JWTSettings:SecretKey"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                //preparing the validation parameters
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                //validating the token
                var principle = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    //returning the user if found
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    return await _usercontext.GetUserById(userId);


                }
            }
            catch (Exception ex)
            {
                //logging the error and returning null
                Console.WriteLine("Exception : " + ex.Message);
                return null;
            }
            //returning null if token is not validated
            return null;
        }
    }
}
