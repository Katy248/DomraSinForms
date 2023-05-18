namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.PieChart;
public class PieChartOptionsBuilder : ChartOptionsBuilder, IPieChartOptionsBuilder
{
    public PieChartOptionsBuilder(IChartOptionsBuilder builder, Dictionary<object, object> data)
    {
        _options = builder.IntermediateInstance;
        InitChart(data);
    }
    private void InitChart(Dictionary<object, object> data)
    {
        var series = new List<object>();
        var labels = new List<object>();
        foreach (var item in data)
        {
            series.Add(item.Value);
            labels.Add(item.Key);
        }

        _options.Series = series.ToList();
        _options.Labels = labels;
    }
}
