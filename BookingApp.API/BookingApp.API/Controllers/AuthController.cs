using Azure.Core;
using BookingApp.API.DTOs.Auth;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public AuthController(AppDbContext context, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestRegister)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == requestRegister.Email);

            if (existingUser != null) return BadRequest("User with this email already exists.");

            var hashedPassword = _passwordHasher.Generate(requestRegister.Password);

            var user = new User(hashedPassword, requestRegister.Email, "User");

            await   _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestLogin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == requestLogin.Email);

            if(user == null) return Unauthorized("Invalid email or password.");

            var validPassword = _passwordHasher.Verify(requestLogin.Password,user.PasswordHash);
            
            if (!validPassword) return Unauthorized("Invalid email or password.");

            var token = _jwtProvider.GenerateToken(user);

            return Ok(new {Token =  token});
        }

    }
}
