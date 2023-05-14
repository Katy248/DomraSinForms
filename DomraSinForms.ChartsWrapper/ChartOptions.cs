using System.Drawing;
using System.Text.Json.Serialization;
using DomraSinForms.ChartsWrapper.Options;

namespace DomraSinForms.ChartsWrapper
{
    public class ChartOptions
    {
       [JsonPropertyName ("pieHole")] 
        public decimal PieHole { get; set; }
        public bool EnableInteractivity { get; set; }
        public string PieSliceBorderColor { get; set; }
        public BackgroundColor BackgroundColor { get; set; }
        public Legend Legend { get; set; }
        [JsonPropertyName ("is3D")]
        public bool Is3D { get; set; }

    }
}