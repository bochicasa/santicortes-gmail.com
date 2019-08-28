using MasGlobal.Common.Model;

namespace MasGlobal.Business.FactoryMethod
{
    public class EmployeeFactory
    {
        public const string HOURLY = "HourlySalaryEmployee";
        public const string MONTHLY = "MonthlySalaryEmployee";

        public BaseEmployeeFactory CreateFactory(EmployeeDTO employeeDTO)
        {
            BaseEmployeeFactory baseEmployeeFactory = null;
            if (employeeDTO.ContractTypeName == HOURLY)
            {
                baseEmployeeFactory = new HourlyEmployeeFactory(employeeDTO);
            }
            else if (employeeDTO.ContractTypeName == MONTHLY)
            {
                baseEmployeeFactory = new MonthlyEmployeeFactory(employeeDTO);
            }
            return baseEmployeeFactory;
        }
    }
}
