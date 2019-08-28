using AutoMapper;
using MasGlobal.Common.Config;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Model;
using MasGlobal.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
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
        private readonly string _masGlobalApiUrl;
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _settings;

        public EmployeeApiRepository(IMapper mapper, IOptions<AppSettings> settings)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _masGlobalApiUrl = $"{_settings.Value.MasGlobalApiUrl}";
        }

        public List<EmployeeDTO> GetAll()
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(_masGlobalApiUrl).Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);

            var employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(result).ToList();
            return employees;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_masGlobalApiUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);

            var employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(result).ToList();
            return employees;
        }
    }
}
