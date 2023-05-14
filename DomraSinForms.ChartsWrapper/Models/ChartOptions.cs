using DomraSinForms.ChartsWrapper.Models.Options;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;

public class ChartOptions
{
    [JsonProperty("pieHole")]
    public decimal PieHole { get; set; }
    public bool EnableInteractivity { get; set; }
    [JsonProperty("pieSliceBorderColor")]
    public string PieSliceBorderColor { get; set; }
    [JsonProperty("backgroundColor")]
    public BackgroundColor BackgroundColor { get; set; }
    [JsonProperty("legend")]
    public Legend Legend { get; set; }
    [JsonProperty("is3D")]
    public bool Is3D { get; set; }
}