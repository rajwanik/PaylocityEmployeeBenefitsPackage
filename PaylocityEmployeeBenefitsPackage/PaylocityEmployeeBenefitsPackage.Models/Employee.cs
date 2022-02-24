using System.ComponentModel.DataAnnotations;

namespace PaylocityEmployeeBenefitsPackage.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual List<EmployeeDependent> Dependents { get; set; }
    }
}
