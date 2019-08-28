namespace MasGlobal.Common.Model
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string ContractTypeName { get; set; }
        public decimal Salary { get; set; }
        public decimal AnualSalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal HourlySalary { get; set; }
    }
}
