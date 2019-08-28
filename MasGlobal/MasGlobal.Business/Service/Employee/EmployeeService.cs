using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MasGlobal.Business.FactoryMethod;
using MasGlobal.Business.Service.Employee.Interfaces;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Repositories.Interfaces;

namespace MasGlobal.Business.Service.Employee
{
    public class EmployeeApiService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeApiService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
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

        public Task<EmployeeDTO> GetById()
        {
            throw new System.NotImplementedException();
        }
    }
}