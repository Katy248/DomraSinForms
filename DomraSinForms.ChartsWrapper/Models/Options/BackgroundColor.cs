using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models.Options
{
    public class BackgroundColor
    {
        [JsonProperty("fillOpacity")]
        public int FillOpacity { get; set; }
    }
}
