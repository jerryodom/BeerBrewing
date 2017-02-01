using Newtonsoft.Json;

namespace BeerBrewingWithReactBoilerplate.Controllers.Manage.Models
{
    public class SetTwoFactorModel
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
