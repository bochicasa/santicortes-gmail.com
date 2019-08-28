using AutoMapper;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Model;
using MasGlobal.DAL.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobal.DAL.Repositories
{
    public class EmployeeApiRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeApiRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<EmployeeDTO> GetAll()
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees").Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);

            var employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(result).ToList();
            return employees;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);

            var employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(result).ToList();
            return employees;
        }

   
        

        EmployeeDTO IEmployeeRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDTO> IEmployeeRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
