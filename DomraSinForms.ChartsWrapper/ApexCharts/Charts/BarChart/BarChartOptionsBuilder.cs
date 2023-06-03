namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.BarChart;
public class BarChartOptionsBuilder : ChartOptionsBuilder, IBarChartOptionsBuilder
{
    public BarChartOptionsBuilder(IChartOptionsBuilder builder, Dictionary<object, object> data)
    {
        _options = builder.IntermediateInstance;
        _options.Chart.Type = "bar";
        InitChart(data);
    }

    public IBarChartOptionsBuilder UseHorizontal(bool use = true)
    {
        _options.PlotOptions.Bar.Horizontal = use;
        return this;
    }

    private void InitChart(Dictionary<object, object> data)
    {
        var series = new List<object>();
        var categories = new List<object>();
        foreach (var item in data)
        {
            series.Add(item.Value);
            categories.Add(item.Key);
        }

        _options.Series.Add(new Series { Data = series, Name = "" });
        _options.XAxis.Categories = categories;
    }
}
