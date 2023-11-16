using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Instagram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private ResponseDTO<LoginResponseDto> _response;
        private readonly IMapper _mapper;
        private ResponseDTO<List<User>> _userResponse;


        public UserController(IUserService userService,
                              IMapper mapper)
        {
            _userService = userService;
            this._mapper = mapper;
            _response = new();
            _userResponse= new();
        }

        [HttpPost("registrar")] // /api/usuario/registrar
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Registrar([FromBody] RegistroRequestDto modelo)
        {
            var isUniqueUser = _userService.IsUniqueUser(modelo.UserName);
            if (!isUniqueUser)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccessfull = false;
                _response.Errors.Add("Usuario ya existe");
                return BadRequest(_response);
            }
            var user = _mapper.Map<User>(modelo);

            var usuario = await _userService.CreateAsync(user);
            if (usuario == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccessfull = false;
                _response.Errors.Add("Error al registrar");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccessfull = true;
            return Ok(_response);

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _userService.GetAllAsync();

            if (users == null)
            {
                _userResponse.StatusCode = HttpStatusCode.BadRequest;
                _userResponse.IsSuccessfull = false;
                _userResponse.Errors.Add("Not Found");
                return BadRequest(_response);
            }



            _userResponse.IsSuccessfull = true;
            _userResponse.StatusCode = HttpStatusCode.OK;
            _userResponse.Data = users;
            return Ok(_response);
        }
    }
}
