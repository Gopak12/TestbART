using System.ComponentModel.DataAnnotations;

namespace TestbART.Model
{
    public class Incident
    {
        [Key]
        public string Name { get; set; }

        public string Decsription { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
