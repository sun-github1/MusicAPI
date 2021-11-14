using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicWeb.API.DTOs.Auth;
using MusicWeb.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        public AuthController(IMapper mapper, UserManager<User> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(UserSignUpDTO userSignUpDTO)
        {
            var user = _mapper.Map<UserSignUpDTO, User>(userSignUpDTO);

            var userExists = await _userManager.FindByEmailAsync(userSignUpDTO.Email);

            if (userExists != null)
            {
                return BadRequest($"User {userSignUpDTO.Email} already exists");
            }

            var userCreateResult = await _userManager.
                CreateAsync(user, userSignUpDTO.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(nameof(SignUp), $"User {userSignUpDTO.Email} created");
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);

        }
    }
}
