using EasySolutionHospital.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasySolutionHospital.API.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? TotalPurchase { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
