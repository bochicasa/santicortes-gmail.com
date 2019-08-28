using MasGlobal.Common.Model;
using MasGloban.View.Services.Employee.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGloban.View.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _employeeApiUrl;

        public EmployeeService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _apiClient = httpClient;
            _settings = settings;
            _employeeApiUrl = $"{_settings.Value.EmployeeApiUrl}";
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var json = await _apiClient.GetStringAsync(_employeeApiUrl);
            List<EmployeeDTO> result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(json);
            return result;
        }
        
    }
}
