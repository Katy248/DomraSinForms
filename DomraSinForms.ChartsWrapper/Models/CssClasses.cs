using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.Models;
public class CssClasses
{
    [JsonPropertyName("headerRow")]
    public string? HeaderRow { get; set; }
    [JsonPropertyName("tableRow")]
    public string? TableRow { get; set; }
    [JsonPropertyName("oddTableRow")]
    public string? OddTableRow { get; set; }
    [JsonPropertyName("selectedRow")]
    public string? SelectedTableRow { get; set; }
    [JsonPropertyName("hoverTableRow")]
    public string? HoverTableRow { get; set; }
    [JsonPropertyName("headerCell")]
    public string? HeaderCell { get; set; }
    [JsonPropertyName("tableCell")]
    public string? TableCell { get; set; }
    [JsonPropertyName("rowNumberCell")]
    public string? RowNumberCell { get; set; }
    [JsonPropertyName("legend")]
    public string? Legend { get; set; }
}
