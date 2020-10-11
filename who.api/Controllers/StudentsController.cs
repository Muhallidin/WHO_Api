using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using who.application.Common;
using who.application.ViewModel;
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
            catch(Exception e)
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
        public async Task<IActionResult> Post([FromBody] StudentVm author)
        {
            var resulr = await udal.Create(author);
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentVm student)
        {
            var resulr = await udal.Create(student);
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
