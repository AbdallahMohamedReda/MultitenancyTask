using System.ComponentModel.DataAnnotations.Schema;

namespace  MultiTenancyTask.Domain.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }
    }
}
