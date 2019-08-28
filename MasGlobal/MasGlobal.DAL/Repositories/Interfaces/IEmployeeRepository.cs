using MasGlobal.Common.Model;
using MasGlobal.DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository 
    {
        List<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int id);
        Task<List<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(int id);
    }
}
