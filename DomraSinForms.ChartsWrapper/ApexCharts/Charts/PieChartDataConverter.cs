using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts;
public class PieChartDataConverter : IChartDataConverter
{
    public string ChartType => "pie";

    public void Convert(Dictionary<object, object> data, Options options)
    {
        var series = new List<object>();
        var labels = new List<object>();
        foreach (var item in data)
        {
            series.Add(item.Value);
            labels.Add(item.Key);
        }

        options.Series = series.ToList();
        options.Labels = labels;
    }
}
