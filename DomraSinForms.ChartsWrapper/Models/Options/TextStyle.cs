﻿using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models.Options
{
    public class TextStyle
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("fontSize")]
        public string? FontSize { get; set; }
        [JsonProperty("fontName")]
        public string? FontName { get; set; }
    }
}
