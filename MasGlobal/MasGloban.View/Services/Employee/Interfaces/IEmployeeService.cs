using MasGlobal.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGloban.View.Services.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployees();
    }
}
