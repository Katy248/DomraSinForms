using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts;
public class BarChartDataConverter : IChartDataConverter
{
    public string ChartType => "bar";

    public Tuple<IEnumerable<object>, IEnumerable<object>> Convert(Dictionary<object, object> data)
    {
        var series = new List<object>();
        var categories = new List<object>();
        foreach (var item in data)
        {
            series.Add(item.Value);
            categories.Add(item.Key);
        }

        return new Tuple<IEnumerable<object>, IEnumerable<object>>(series, categories);
    }
}
