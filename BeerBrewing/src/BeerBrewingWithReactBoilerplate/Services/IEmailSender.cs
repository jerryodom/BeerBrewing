using System.Threading.Tasks;

namespace BeerBrewingWithReactBoilerplate.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
