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
            catch (ExternalException e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Post([FromBody] AuthorVm author)
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
    }
}
