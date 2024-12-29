using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FakeBK.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int SSN { get; set; }

        public string? Name { get; set; }   
        public string? Address  { get; set; }

        
    }
}
