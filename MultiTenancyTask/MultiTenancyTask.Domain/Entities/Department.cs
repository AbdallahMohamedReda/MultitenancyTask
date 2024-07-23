using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MultiTenancyTask.Domain.Entities
{
    public class Department:TenantParrentClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManageName { get; set; }
        //[Required]
        [JsonIgnore]
        public virtual List<Employee> Employees { get; set; }
    }
}
