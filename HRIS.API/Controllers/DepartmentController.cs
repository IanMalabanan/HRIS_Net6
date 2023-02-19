using HRIS.Application.Departments.Dtos;
using HRIS.Application.Departments.Queries;
using HRIS.Application.Employees.Dtos;
using HRIS.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "HRIS")]
    [Route("api/[controller]")]
    public class DepartmentController : ApiControllerBase
    {
        [HttpGet]
        [Route("getalldepartment")]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> GetDepartments()
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
