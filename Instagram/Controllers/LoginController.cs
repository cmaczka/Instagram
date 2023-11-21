using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Instagram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private LoginResponseDto _response;
       

        public LoginController(IUserService userService,
                             IMapper mapper)
        {
            _userService = userService;
            this._mapper = mapper;
            _response = new();
        }

        [HttpPost("login")] // /api/usuario/login
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            LoginResponseDto loginResponse = await _userService.Login(loginRequestDto);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token) || !loginResponse.IsValidPassword)
            {
                _response.StatusCode = StatusCodes.Status400BadRequest;
                _response.Errors = "Username or Password is incorrect";
                return BadRequest(_response);
            }
            _response.StatusCode = StatusCodes.Status200OK;
            loginResponse.User.Password = "PRUEBA";
            _response.Token = loginResponse.Token;
            return Ok(_response);
        }

       


    }
}
