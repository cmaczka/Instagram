using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Instagram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private ResponseDTO<bool> _response;
        private readonly IMapper _mapper;

        public PostController(IPostService postService,
                            IMapper mapper)
        {
            _postService = postService;
            this._mapper = mapper;
            _response = new();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDto modelo)
        {
            var post= _mapper.Map<Post>(modelo);

            var result = await _postService.CreateAsync(post);
            if (result == false)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccessfull = false;
                _response.Errors.Add("Error when creating post");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccessfull = true;
            return Ok(_response);

        }
    }
}
