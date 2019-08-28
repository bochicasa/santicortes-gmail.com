using System;

namespace MasGlobal.Business.FactoryMethod
{
    public class HourlyEmployee : IEmployee
    {
        public decimal GetSalary(decimal baseSalary)
        {
            try
            {
                return 120 * baseSalary * 12;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
