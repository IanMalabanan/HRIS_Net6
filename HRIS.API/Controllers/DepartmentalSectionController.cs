using HRIS.Application.DepartmentalSections.Dtos;
using HRIS.Application.DepartmentalSections.Queries;
using HRIS.Application.Departments.Dtos;
using HRIS.Application.Departments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.API.Controllers
{
    [ApiExplorerSettings(GroupName = "HRIS")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentalSectionController : ApiControllerBase
    {
        [HttpGet]
        [Route("getalldepartmentalsection")]
        //Run and use Postman to call this request
        public async Task<ActionResult<IEnumerable<GetDepartmentSectionDto>>> GetDepartmentalSection()
        {
            try
            {
                var _result = await Mediator.Send(new GetListofDepartmentalSectionQuery() { });

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
