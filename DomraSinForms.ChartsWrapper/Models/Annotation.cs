using DomraSinForms.ChartsWrapper.Models.Options;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;

public class Annotation
{
    [JsonProperty("textStyle")]
    public TextStyle? TextStyle { get; set; }
}