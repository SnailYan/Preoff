using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Preoff.Entity;

namespace Preoff.Controllers
{
    /// <summary>
    /// ��Ȩ������
    /// </summary>
    [Route("[controller]")]
    public class AuthorizeController : Controller
    {
        private JwtSettings _jwtSettings;
        private PreoffContext _dbContext;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="_jwtSettingsAccesser">ע��Jwt��֤</param>
        /// <param name="_db">ע�����ݿ�����</param>
        public AuthorizeController(IOptions<JwtSettings> _jwtSettingsAccesser, PreoffContext _db)
        {
            _jwtSettings=_jwtSettingsAccesser.Value;
            _dbContext = _db;
        }
        /// <summary>
        /// ��ȡJWT Token
        /// </summary>
        /// <param name="userModel">�û�</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Token([FromBody]UserTable userModel)
        {
            if(ModelState.IsValid)
            {
                //var a=_dbContext.Tuser.FirstOrDefault(u => (u.CName == userModel.CName) && (u.CValue == userModel.CValue));
                //if (a is null)
                //{
                //    return BadRequest();
                //}

                //var claims=new Claim[]{
                //    new Claim(ClaimTypes.Name,userModel.CName),
                //    new Claim(ClaimTypes.Role,"user"),
                //    //new Claim("SuperAdminOnly","true")
                //};
                var claims = new Claim[]{
                    new Claim(ClaimTypes.Name,userModel.LoginName),
                    new Claim(ClaimTypes.Role,"user"),
                    //new Claim("SuperAdminOnly","true")
                };


                var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var token= new JwtSecurityToken(
                    _jwtSettings.Issuer,
                    _jwtSettings.Audience,
                    claims,
                    DateTime.Now,DateTime.Now.AddMinutes(_jwtSettings.TimeOut),
                    creds);

                return Ok(new {token=new JwtSecurityTokenHandler().WriteToken(token)});


            }
            return BadRequest();
        }
    }
}