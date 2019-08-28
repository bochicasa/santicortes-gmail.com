using AutoMapper;
using FluentAssertions;
using MasGlobal.Common.Config;
using MasGlobal.Common.Model;
using MasGlobal.DAL.Repositories;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MasGlobal.Test.Employee
{
    public class EmployeeRepositoryTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IOptions<AppSettings>> _settingMock;
        public EmployeeRepositoryTest()
        {
            _mapperMock = new Mock<IMapper>();
            _settingMock = new Mock<IOptions<AppSettings>>();
        }

        [Fact]
        public async void Get_All_employees_success_From_Moq()
        {
            //Arrange
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            AppSettings app = new AppSettings() { MasGlobalApiUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees" };
            _settingMock.Setup(ap => ap.Value).Returns(app);
            List<EmployeeDTO> employeeListStuffs = GetEmployeeList();
            _mapperMock.Setup(m => m.Map<IEnumerable<DAL.Model.Employee>, IEnumerable<EmployeeDTO>>(It.IsAny<IEnumerable<DAL.Model.Employee>>())).Returns(employeeListStuffs);

            //Act
            EmployeeApiRepository employeeApiRepository = new EmployeeApiRepository(_mapperMock.Object, _settingMock.Object);
            var result = await employeeApiRepository.GetAllAsync();

            //Assert
            var okResult = result.Should().BeOfType<List<EmployeeDTO>>().Subject;
            result.Should().HaveCountGreaterThan(1);
        }

        private static List<EmployeeDTO> GetEmployeeList()
        {
            return new List<EmployeeDTO> {
                new EmployeeDTO {  Id = 1,
                                            Name="Juan",
                                            ContractTypeName="HourlySalaryEmployee",
                                            RoleId=1,
                                            RoleName="Administrator",
                                            RoleDescription=null,
                                            HourlySalary=60000,
                                            MonthlySalary= 80000



                },
                new EmployeeDTO { Id = 2,Name="Sebastian",
                                            ContractTypeName="MonthlySalaryEmployee",
                                            RoleId=2,
                                            RoleName="Contractor",
                                            RoleDescription=null,
                                            HourlySalary=60000,
                                            MonthlySalary= 80000
                }
            };
        }
    }
}
