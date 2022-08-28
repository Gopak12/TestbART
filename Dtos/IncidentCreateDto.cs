using System.ComponentModel.DataAnnotations;
using TestbART.Model;

namespace TestbART.Dtos
{
    public class IncidentCreateDto
    {
        [Required]
        public string Decsription { get; set; }

        [Required]
        public List<Account> Accounts { get; set; }
    }
}
