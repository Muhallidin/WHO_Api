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
        
        public async Task<IActionResult> course(int id)
        {
            try
            {
                var result = await udal.GetCourse(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "No record found!" });
                }
            }
            catch (ExternalException e)
            {
                return BadRequest(new { message = e.Message });
            }
            //var user = await _userManager.FindByNameAsync(model.UserName);
          

        }
        [HttpGet("[controller]")]
        public async Task<object> courses()
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
                    return NotFound(new { message = "No record found!" });
                }
            }
            catch (ExternalException e) {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPost("[controller]")]
        public async Task<IActionResult> Post([FromBody]CourseVm courses)
        {
            //var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await udal.Create(courses);
            if (result != null)
            {
                return Ok(new
                {
                    Id = result,
                    message = "Successfully create Course",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }
    }
}
