using DomraSinForms.ChartsWrapper.Models.Options;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;

public class ChartOptions
{
    [JsonProperty("pieHole")]
    public decimal PieHole { get; set; } = 0m;

    [JsonProperty("enableInteractivity")]
    public bool EnableInteractivity { get; set; } = true;

    [JsonProperty("pieSliceBorderColor")]
    public string? PieSliceBorderColor { get; set; } = null;

    [JsonProperty("backgroundColor")]
    public BackgroundColor BackgroundColor { get; set; }

    [JsonProperty("legend")]
    public Legend Legend { get; set; }

    [JsonProperty("is3D")]
    public bool Is3D { get; set; } = false;

    [JsonProperty("allowHtml")]
    public bool AllowHtml { get; set; } = false;

    [JsonProperty("cssClassNames")]
    public CssClasses CssClassNames { get; set; }
}