using MasGlobal.Common.Model;

namespace MasGlobal.Business.FactoryMethod
{
    public class HourlyEmployeeFactory : BaseEmployeeFactory
    {
        public HourlyEmployeeFactory(EmployeeDTO employee) : base(employee)
        {

        }
        public override IEmployee Create()
        {
            HourlyEmployee hourlyEmployeeDTO = new HourlyEmployee();
            _employeeDTO.AnualSalary = hourlyEmployeeDTO.GetSalary(_employeeDTO.HourlySalary);
            return hourlyEmployeeDTO;
        }
    }
}
