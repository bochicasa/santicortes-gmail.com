using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Business.FactoryMethod
{
    public class MonthlyEmployee : IEmployee
    {
        public decimal GetSalary(decimal baseSalary)
        {
            try
            {
                return baseSalary * 12;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
