using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models.Options
{
    public class Legend
    {
        [JsonProperty("textStyle")]
        public TextStyle TextStyle { get; set; }
        [JsonProperty("position")]
        public string? Position { get; set; } = "left";
    }
}
