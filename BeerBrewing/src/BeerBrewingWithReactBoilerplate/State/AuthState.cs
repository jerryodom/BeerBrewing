using Newtonsoft.Json;
using BeerBrewingWithReactBoilerplate.Models.Api;

namespace BeerBrewingWithReactBoilerplate.State
{
    public class AuthState
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("loggedIn")]
        public bool LoggedIn { get; set; }
    }
}
