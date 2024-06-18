﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Extensions;
public static class ChartOptionsExtensions
{
    public static JsonSerializerSettings Settings => new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore,
    };
    public static IHtmlContent Serialize(this ChartOptions options, Action<JsonSerializerSettings>? serializerConfig = null)
    {
        var settings = Settings;
        serializerConfig?.Invoke(settings);
        return new HtmlString(JsonConvert.SerializeObject(options, settings));
    }
}
