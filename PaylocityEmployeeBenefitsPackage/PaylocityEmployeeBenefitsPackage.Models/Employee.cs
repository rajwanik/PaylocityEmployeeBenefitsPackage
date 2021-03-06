using PaylocityEmployeeBenefitsPackage.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaylocityEmployeeBenefitsPackage.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = Constants.EmployeeNameErrorMessage)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name ="Salary Per Year")]
        public double Salary { get; set; }

        public virtual List<EmployeeDependent> Dependents { get; set; }

        [NotMapped]
        public double SalaryAfterDeduction { get; set; }

        [NotMapped]
        public double EmployeeBenefitCostBeforeDeduction { get; set; }

        [NotMapped]
        public double EmployeeDependentBenefitCostBeforeDeduction { get; set; }
    }
}
