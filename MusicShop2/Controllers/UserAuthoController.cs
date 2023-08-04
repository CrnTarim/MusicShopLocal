using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicShopEntities.DTOs;
using MusicShopEntities.Entities;
using MusicShopEntities.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MusicShop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<UserAutho> _service;
        public UserAuthoController(IMapper mapper, IService<UserAutho> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserAutho>> Register(UserAuthoDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            var user = new UserAutho
            {
                Name = userDto.Name,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt
            };

            await _service.AddAsync(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserAuthoDto userDto)
        {

            var entity =  _service.Where(x=>x.Name==userDto.Name).FirstOrDefault();

            if (entity == null)
            {                
                return Ok("wrong username");
            }

            if (!VerifyPasswordHash(userDto.Password, entity.PassWordHash, entity.PassWordSalt))
            {
               
                return Ok("password");
            }

            return CreatedToken(entity);
        }
            private string CreatedToken(UserAutho user)
            {
                List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name)
               
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
