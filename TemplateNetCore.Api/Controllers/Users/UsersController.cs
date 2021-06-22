﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Users;
using TemplateNetCore.Domain.Entities.Users;
using TemplateNetCore.Domain.Interfaces.Users;

namespace TemplateNetCore.Api.Controllers.Users
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] PostSignUpDto signUpDto)
        {
            await _service.SignUp(_mapper.Map<User>(signUpDto));
            return Ok();
        }

        [HttpPost("auth")]
        public async Task<ActionResult<GetLoginResponseDto>> Login([FromBody] PostLoginDto postLoginDto)
        {
            return Ok(await _service.Login(postLoginDto));
        }

        [HttpPut("users/profile-image")]
        public async Task<ActionResult<GetUpdateProfilePhotoResponse>> UpdateProfileImage([FromForm] IFormFile file)
        {
            var response = await _service.UpdateProfilePhoto(file.OpenReadStream(), file.ContentType);
            return Ok(response);
        }
    }
}
