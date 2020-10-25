using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using who.application.Common;
using who.domain.Common;
using who.infrastructure.Services;

namespace who.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //private readonly IConfiguration config;
        private readonly UserDal udal;
        //private readonly UserManager<TokenUser> _userManager;

        public UserController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {

            this.udal = new UserDal(appSetting.Value, con.Value);

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] LogIn model)
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
