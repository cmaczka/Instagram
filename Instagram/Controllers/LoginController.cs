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
        private ResponseDTO<LoginResponseDto> _response;
       

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
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var loginResponse = await _userService.Login(loginRequestDto);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccessfull = false;
                _response.Errors.Add("Username or Password is incorrect");
                return BadRequest(_response);
            }
            _response.IsSuccessfull = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = loginResponse;
            return Ok(_response);
        }

       


    }
}
