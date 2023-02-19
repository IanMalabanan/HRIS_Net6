using HRIS.Application.Departments.Dtos;
using HRIS.Application.Departments.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.API.Controllers
{
    [ApiExplorerSettings(GroupName = "HRIS")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentalSectionController : ApiControllerBase
    {
        [HttpGet]
        [Route("getalldepartmentalsection")]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> GetDepartmentalSection()
        {
            try
            {
                var _result = await Mediator.Send(new GetListofDepartmentQuery() { });

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
