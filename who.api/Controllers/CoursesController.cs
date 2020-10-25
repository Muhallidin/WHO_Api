using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using who.application.Common;
using who.application.ViewModel;
using who.domain.Entities;
using who.infrastructure.Services;

namespace who.api.Controllers
{
    [Route("api/v1.0")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseDal udal;
        public CoursesController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            this.udal = new CourseDal(appSetting.Value, con.Value);
        }

        [HttpGet("Course/{id}")]
        public async Task<IActionResult> Course(int id)
        {

            try
            {
                var result = await udal.GetCourse(id);
                if (result != null)
                {
                    return Ok(new { status = true, result });
                }
                else
                {
                    return NotFound(new { status = false, message = "No record found!" });
                }
            }
            catch (ExternalException e)
            {
                return BadRequest(new { status = false, message = e.Message });
            }

        }

        [HttpDelete("Course/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await udal.Delete(id);
                if (result != null)
                {
                    return Ok(new { status = false, message = result });
                }
                else
                {
                    return NotFound(new { status = false, message = "No record found!" });
                }
            }
            catch (ExternalException e)
            {
                return BadRequest(new { status = false, message = e.Message });
            }
        }


        [HttpGet("[controller]")]
        public async Task<object> Courses()
        {
            try
            {
                var result = await udal.GetAllCourse();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { status = true, message = "No record found!" });
                }
            }
            catch (ExternalException e)
            {
                return BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpPost("Course")]
        public async Task<IActionResult> Post([FromBody] Courses courses)
        {
            //var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await udal.Create(courses);
            if (result != null)
            {
                return Ok(new
                {
                    status =true,
                    Id = result,
                    message = "Successfully create the enrolled course",
                });
            }
            else
            {
                return BadRequest(new { status = true, message = "Invalid Input" });
            }
        }

        [HttpPut("Course/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Courses courses)
        {
            var result = await udal.Update(id, courses);
            if (result != null)
            {
                return Ok(new
                {
                    status = true,
                    Id = result,
                    message = "Successfully Update the enrolled course",
                });
            }
            else
            {
                return BadRequest(new { status = true, message = "Invalid Input" });
            }

        }
    }
}
