using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MasGlobal.Business.FactoryMethod;
using MasGlobal.Business.Service.Employee.Interfaces;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Repositories.Interfaces;
using System.Linq;
using System;
using Microsoft.Extensions.Options;
using MasGlobal.Common.Config;

namespace MasGlobal.Business.Service.Employee
{
    public class EmployeeApiService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _settings;

        public EmployeeApiService(IEmployeeRepository employeeRepository, IMapper mapper, IOptions<AppSettings> settings)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            foreach (EmployeeDTO employee in employees)
            {
                BaseEmployeeFactory employeeFactory = new EmployeeFactory().CreateFactory(employee);
                employeeFactory.AnnualSalary();
            }
            return employees;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var employees = await _employeeRepository.GetAllAsync();
            EmployeeDTO employee = employees.Where(i => i.Id == id).FirstOrDefault();
            BaseEmployeeFactory employeeFactory = new EmployeeFactory().CreateFactory(employee);
            employeeFactory.AnnualSalary();
            return employee;
        }
    }
}