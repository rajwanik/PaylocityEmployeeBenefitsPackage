using System.ComponentModel.DataAnnotations;

namespace PaylocityEmployeeBenefitsPackage.Models
{
    public class EmployeeDependent
    {
        [Key]
        public int EmployeeDependentIdentifier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public RelationshipType Relationship { get; set; }

        public int EmployeeID { get; set; }
    }
}
