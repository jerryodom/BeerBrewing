using System.Threading.Tasks;

namespace BeerBrewingWithReactBoilerplate.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
