using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.Models;
public class BarChart : Chart
{
    public const string BarChartName = nameof(BarChart);
    public BarChart(string elementId, IEnumerable<object[]> dataTable, ChartOptions options) : base(elementId, BarChartName, dataTable, options)
    {
    }
}
