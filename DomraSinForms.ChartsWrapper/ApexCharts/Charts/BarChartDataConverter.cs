using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts;
public class BarChartDataConverter : IChartDataConverter
{
    public string ChartType => "bar";

    public void Convert(Dictionary<object, object> data, Options options)
    {
        var series = new List<object>();
        var categories = new List<object>();
        foreach (var item in data)
        {
            series.Add(item.Value);
            categories.Add(item.Key);
        }

        options.Series.Add(new Series { Data = series, Name = "" });
        options.XAxis.Categories = categories;
    }
}
