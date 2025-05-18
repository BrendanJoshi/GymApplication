using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymApplication.Data
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int? PersonalInformationId { get; set; }
    }
}
