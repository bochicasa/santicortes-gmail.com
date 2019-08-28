
using MasGlobal.Common.Model;
using System;

namespace MasGlobal.Business.FactoryMethod
{
    public abstract class BaseEmployeeFactory
    {
        protected EmployeeDTO _employeeDTO;
        public BaseEmployeeFactory(EmployeeDTO employeeDTO)
        {
            _employeeDTO = employeeDTO ?? throw new ArgumentNullException(nameof(employeeDTO));
        }
        public abstract IEmployee Create();
        public EmployeeDTO AnnualSalary()
        {
            IEmployee employee = Create();
            return _employeeDTO;
        }
    }
}
