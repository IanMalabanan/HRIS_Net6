using HRIS.API.Controllers;
using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Dtos;
using HRIS.Application.Employees.Queries;
using HRIS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Net6_CQRSApproach.Controllers
{
    [ApiExplorerSettings(GroupName = "HRIS")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class EmployeeController : ApiControllerBase
    {
        //[AllowAnonymous]
        [HttpGet]
        [Route("getallemployees")]
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
