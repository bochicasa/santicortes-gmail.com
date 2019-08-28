using MasGlobal.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Business.Service.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById();
    }
}
