using System.ComponentModel.DataAnnotations;

namespace BeerBrewingWithReactBoilerplate.Controllers.Account.Models
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
