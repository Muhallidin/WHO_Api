//using Microsoft.AspNetCore.Components;
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
    [Route("api/v1.0/")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly CourseEnrollDal dal;
        public EnrollController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            this.dal = new CourseEnrollDal(appSetting.Value, con.Value);
        }



        [HttpGet("[controller]")]
        public async Task<IActionResult> Get()
        {

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await dal.Select();

            if (result != null)
            {
                return Ok(new
                {
                    Status = true,result
                });
            }
            else
            {
                return BadRequest(new { message = "No record found!" });
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseEnroll courses)
        {
            var resulr = await dal.Create(courses);
            if (resulr != null)
            {
                return Ok(new
                {
                    message = "Successfully create course enroll",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, [FromBody] CourseEnroll courses)
        {
            var resulr = await dal.Update(Id, courses);
            if (resulr != null)
            {
                return Ok(new
                {
                    StatusCode = true,
                    message = "Successfully update the user",
                });
            }
            else
            {
                return BadRequest(new { StatusCode = false, message = "Invalid Input" }); ;
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DelateById(int Id)
        {
            try
            {
                var result = await dal.DelateById(Id);
                if (result > 0)
                {
                    return Ok(new
                    {
                        Status = true,
                        message = "Successfully Delete the user"
                    });
                }
                else
                {
                    return BadRequest(new { Status = false, message = "Invalid Input" }); ;
                }
            }
            catch(Exception ex) 
            {

                return BadRequest(new { Status = false, message = ex.Message } );
            }
        }
    }
}
