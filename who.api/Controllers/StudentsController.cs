
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using who.application.Common;
using who.application.ViewModel;
using who.domain.Entities;
using who.infrastructure.Services;

namespace who.api.Controllers
{
    [Route("api/v1.0")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDal udal;
        public StudentsController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            this.udal = new StudentDal(appSetting.Value, con.Value);
        }

        [HttpGet("Student/{id}")]

        public async Task<IActionResult> Student(int id)
        {
            try
            {
                var result = await udal.GetStudent(id);

                if (result != null)
                {
                    return Ok(new
                    {
                        result
                    });
                }
                else
                {
                    return NotFound(new { message = "No record found!" });
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Sequence contains no elements"))
                {
                    return NotFound(new { message = "No record found!" });
                }

                return BadRequest(new { message = "No record found!" });
            }
            //var user = await _userManager.FindByNameAsync(model.UserName);Try


        }
        [HttpGet("[controller]")]
        public async Task<object> Students()
        {
            try
            {
                var result = await udal.GetAllStudent();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "No record found!" });
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Sequence contains no elements"))
                {
                    return NotFound(new { message = "No record found!" });
                }

                return BadRequest(new { message = "No record found!" });
            }
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Post([FromBody] Student author)
        {
            var resulr = await udal.Create(author);
            if (resulr != null)
            {
                return Ok(new
                {
                    message = "Successfully create Student",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }

        // PUT api/values/5
        [HttpPut("Student/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            var resulr = await udal.Update(id, student);
            if (resulr != null)
            {
                return Ok(new
                {
                    message = "Successfully create Student",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }
        }

        // PUT api/values/5
        [HttpDelete("Student/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resulr = await udal.Delete(id);
            if (resulr > 0)
            {
                return Ok(new
                {
                    message = "Successfully delete Student",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }
        }

    }
}
