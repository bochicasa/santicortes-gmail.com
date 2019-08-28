using MasGlobal.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository 
    {
        List<EmployeeDTO> GetAll();
        Task<List<EmployeeDTO>> GetAllAsync();
    }
}
