using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorDal udal;
        public AuthorsController(IOptions<ApplicationSettings> appSetting, IOptions<ConnectionSetting> con)
        {
            this.udal = new AuthorDal(appSetting.Value, con.Value);
        }

        [HttpGet("Author/{id}")]
        public async Task<IActionResult> Author(int id)
        {

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await udal.GetAuthor(id);

            if (result != null)
            {
                return Ok(new
                {
                    result
                });
            }
            else
            {
                return BadRequest(new { message = "No record found!" });
            }

        }

        [HttpDelete("Author/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {

                var resulr = await udal.Delete(Id);
                if (resulr > 0)
                {
                    return Ok(new
                    {
                        status = true,
                        message = "Successfully Delete Author",
                    });
                }
                else
                {
                    return BadRequest(new { message = "Invalid Input" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        status = false,
                        message = ex.Message
                    }); ;
            }
        }
        [HttpPut("Author/{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Author author)
        {
            var resulr = await udal.Update(Id, author);
            if (resulr != null)
            {
                return Ok(new
                {
                    message = "Successfully create Author",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }
        [HttpGet("[controller]")]
        public async Task<object> Authors()
        {
            try
            {
                var result = await udal.GetAllAuthor();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "No record found!" });
                }
            }
            catch (ExternalException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            var resulr = await udal.Create(author);
            if (resulr != null)
            {
                return Ok(new
                {
                    message = "Successfully create Author",
                });
            }
            else
            {
                return BadRequest(new { message = "Invalid Input" });
            }

        }
       

       


    }
}
