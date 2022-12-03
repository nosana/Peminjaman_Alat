﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<AccountRepository, Account>
    {
        private AccountRepository _accountRepository;
        private MyContext myContext;
        public IConfiguration _configuration;
        public AccountsController(IConfiguration config, AccountRepository accountRepository) : base(accountRepository)
        {
            this._accountRepository = accountRepository;
            _configuration = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                var data = _accountRepository.Login(login);

                if (data != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", data.Id.ToString()),
                        new Claim("FullName", data.FullName),
                        new Claim("Email", data.Email),
                        new Claim("Role", data.Roles)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    string tokenCode = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Success",
                        token = tokenCode
                    });
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Email atau Password Anda Salah!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
        [AllowAnonymous]
        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword(ChangePassVM changePassVM)
        {
            try
            {
                var data = _accountRepository.ChangePassword(changePassVM);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Ganti password tidak berhasil"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Ganti Password Baru Sudah Berhasil"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("ForgotPassword")]
        
        public ActionResult ForgotPassword(ForgotPassVM forgotPassVM)
        {
            try
            {
                var data = _accountRepository.ForgotPassword(forgotPassVM);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "lupa password gagal"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Password lama telah di ganti"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }


    }
}
