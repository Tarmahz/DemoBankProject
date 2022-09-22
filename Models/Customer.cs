using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DemoBankProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
      
        public string Address { get; set; }
        public string City { get; set; }
        public string LandMark { get; set; }
        public string State { get; set; }

        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string Mobile { get; set; }
 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Account> Accounts
        {
            get; set; 
        }

    }
}
