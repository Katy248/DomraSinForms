using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;
public class PieChart : Chart
{
    const string PieChartName = nameof(PieChart);
    public PieChart(string elementId, IEnumerable<object[]> dataTable, ChartOptions options) : base(elementId, PieChartName, dataTable, options)
    {
        
    }
    
    
}
