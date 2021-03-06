﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceImage.Api.Models.Registration;
using FaceImage.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FaceImage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //public async Task<IActionResult> Login()
        //{

        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"Test", "Test2"};
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await this._userManager.FindByIdAsync(id);

            var result = await this._userManager.DeleteAsync(user);

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new AppUser()
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age ?? ""
            };

            //var passwordHash = _userManager.PasswordHasher.HashPassword(user, "password");

            var result = await this._userManager.CreateAsync(user, "password");

            if (result.Succeeded)
            {
                //should be a 201 message
                return Ok();
            }
            else
            {
                //if there is an error eg, user already exists
                return new BadRequestObjectResult(result.Errors);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("protected")]
        [Authorize(Policy = "ApiUser")]
        public IActionResult Protected()
        {
            return Ok();
        }
    }
}