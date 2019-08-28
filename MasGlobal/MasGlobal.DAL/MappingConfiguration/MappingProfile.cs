using AutoMapper;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Model;

namespace MasGlobal.DAL.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
