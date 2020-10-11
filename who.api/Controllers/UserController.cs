using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using who.application.Common;
using who.domain.Common;
using who.infrastructure.Services;

namespace who.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IApplicationSettings _appSetting;
        //private readonly IConfiguration config;
        private readonly UserDal udal;
        //private readonly UserManager<TokenUser> _userManager;

        public UserController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            //_userManager = userManager;
            _appSetting = appSetting.Value;
            //this.config = configuration;
            this.udal = new UserDal(appSetting.Value, con.Value);

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody]LogIn model)
        {

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var User = await udal.LogIn(model);
            if (User.UserID != null)
            {
                return Ok(new
                {
                    Token = User.UserID,
                    
                });
            }
            else
            {
                return BadRequest(new { message = "Username or password is invalid" });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogIn model)
        {

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var User = await udal.Create(model);
            if (User != null)
            {
                return Ok(new
                {
                    message = "Successfully create user",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }
    }
}
