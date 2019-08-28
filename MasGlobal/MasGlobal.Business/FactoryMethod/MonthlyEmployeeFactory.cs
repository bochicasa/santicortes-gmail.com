using MasGlobal.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Business.FactoryMethod
{
    public class MonthlyEmployeeFactory : BaseEmployeeFactory
    {
        public MonthlyEmployeeFactory(EmployeeDTO employee) : base(employee)
        {

        }
        public override IEmployee Create()
        {
            MonthlyEmployee monthlyEmployeeDTO = new MonthlyEmployee();
            _employeeDTO.AnualSalary = monthlyEmployeeDTO.GetSalary(_employeeDTO.MonthlySalary);
            return monthlyEmployeeDTO;
        }
    }
}
