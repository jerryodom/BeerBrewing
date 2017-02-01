using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BeerBrewingWithReactBoilerplate.Controllers.Account.Models
{
    public class VerifyCodeModel
    {
        [Required]
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("rememberBrowser")]
        public bool RememberBrowser { get; set; }

        [JsonProperty("rememberMe")]
        public bool RememberMe { get; set; }
    }
}
