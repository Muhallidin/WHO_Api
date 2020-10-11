using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using who.application.Common;
using who.application.ViewModel;
using who.infrastructure.Services;

namespace who.api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly CourseEnrollDal dal;
        public EnrollController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            this.dal = new CourseEnrollDal(appSetting.Value, con.Value);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseEnrollVm courses)
        {
            var resulr = await dal.Create(courses);
            if (resulr != null)
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
