using DomraSinForms.ChartsWrapper.Models.Options;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;

public class AxisOptions
{
    [JsonProperty("title")]
    public string? Title { get; set; }
    [JsonProperty("titleTextStyle")]
    public TextStyle? TitleTextStyle { get; set; }
}