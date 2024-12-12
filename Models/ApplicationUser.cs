using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required , MaxLength (100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }

        
        [MaxLength(50)] // Optional but can add a length limit
        [Display(Name = "Gender")]
        public string? Gender { get; set; }

        // Age should be a valid integer, with a realistic range
        
        [Range(1, 120, ErrorMessage = "Please enter a valid age between 1 and 120.")]
        public int? Age { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
