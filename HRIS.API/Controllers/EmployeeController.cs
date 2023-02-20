using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Dtos.Commands;
using HRIS.Application.Employees.Dtos.Queries;
using HRIS.Application.Employees.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.API.Controllers
{
    [ApiExplorerSettings(GroupName = "HRIS")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : ApiControllerBase
    {
        [HttpGet]
        [Route("getallemployees")]
        //Run and use Postman to call this request
        public async Task<ActionResult<IEnumerable<GetEmployeesDto>>> GetEmployees()
        {
            try
            {
                var _result = await Mediator.Send(new GetEmployeesQuery() { });

                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }


        [HttpPost("createemployee")]
        //Run and use Postman to call this request
        public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee(CreateEmployeeCommand request)
        {
            try
            {
                var _results = await Mediator.Send(request);
                return Ok(_results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
