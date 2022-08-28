using System.ComponentModel.DataAnnotations;

namespace TestbART.Model
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Account Account { get; set; }

        [Key]
        public string Email { get; set; }
        
    }
}
