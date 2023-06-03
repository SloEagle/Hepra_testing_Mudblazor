﻿using Domain.Entities;
using Hepra_testing_Mudblazor.Server.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hepra_testing_Mudblazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();

            if(users == null)
            {
                return NotFound(null);
            }
            else
            {
                return Ok(users);
            }
        }
    }
}