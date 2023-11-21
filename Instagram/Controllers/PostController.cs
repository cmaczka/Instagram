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

        [HttpPost("Like")]
        public async Task<IActionResult> LikePost([FromBody] LikeRequestDTO modelo)
        {
            var like = _mapper.Map<Like>(modelo);

            var result = await _postService.LikeAsync(like);
            if (result == false)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccessfull = false;
                _response.Errors.Add("There was an error");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccessfull = true;
            return Ok(_response);

        }
        [HttpPost]
        [Route("Commnent")]
        public async Task<IActionResult> CommentPost([FromBody] CommentRequestDTO modelo)
        {
            try
            {
                var comment = _mapper.Map<Comment>(modelo);

                var result = await _postService.CommentAsync(comment);
                if (result == false)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccessfull = false;
                    _response.Errors.Add("There was an error");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccessfull = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccessfull = false;
                _response.Errors.Add("There was an error adding the comment");
                return BadRequest(_response);
            }
            

        }
    }
}
