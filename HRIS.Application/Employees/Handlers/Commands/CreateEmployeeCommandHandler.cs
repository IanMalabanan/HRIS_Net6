using AutoMapper;
using HRIS.Application.Common.Interfaces;
using HRIS.Application.Common.Interfaces.Repositories;
using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Dtos;
using HRIS.Application.Utils;
using HRIS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeDto>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionScopeFactory _transactionScopeFactory;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomEmployeeRepository _customEmployeeRepository;

        public CreateEmployeeCommandHandler(IMapper mapper, ITransactionScopeFactory transactionScopeFactory, IEmployeeRepository employeeRepository, ICustomEmployeeRepository customEmployeeRepository)
        {
            _mapper = mapper;
            _transactionScopeFactory = transactionScopeFactory;
            _employeeRepository = employeeRepository;
            _customEmployeeRepository = customEmployeeRepository;
        }

        public async Task<CreateEmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _transactionScopeFactory.Create())
            {
                IEnumerable<Employee> getemployees;

                if (string.IsNullOrEmpty(request.MiddleName))
                {
                    getemployees = await _employeeRepository.GetAllAsync
                     (x => (x.FirstName + " " + x.LastName)
                         .Contains(request.FirstName + " " + request.LastName)
                     );
                }
                else
                {
                    getemployees = await _employeeRepository.GetAllAsync
                    (x =>
                        (x.FirstName + " " + x.MiddleName + " " + x.LastName)
                        .Contains(request.FirstName + " " + request.MiddleName + " " + request.LastName)
                    );
                }

                if (getemployees.Any())
                    throw new Exception("Employee already registered.");

                var counter = await _employeeRepository.GetAllAsync();

                var _employee = _mapper.Map<Employee>(request);

                var res = await _employeeRepository.AddAsync(_employee);

                var cusEmpDto = new CreateCustomEmployeeDto
                {
                    EmpID = res.EmpID,
                    DefinedEmpID = $"Emp-{NumberFormatUtil.AddZeroPrefix(9, res.EmpID)}"
                };

                var _employeess = _mapper.Map<CustomEmployee>(cusEmpDto);

                await _customEmployeeRepository.AddAsync(_employeess);

                var _return = _mapper.Map<CreateEmployeeDto>(_employee);

                if(_return.CreateCustomEmployeeDto == null)
                {
                    _return.CreateCustomEmployeeDto = cusEmpDto;
                }

                scope.Complete();

                return _return;
            }
        }


    }
}

