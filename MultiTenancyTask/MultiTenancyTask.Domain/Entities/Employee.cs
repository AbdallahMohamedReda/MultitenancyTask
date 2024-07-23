using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

 namespace MultiTenancyTask.Domain.Entities

{
    public class Employee:TenantParrentClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
       
    }
}
