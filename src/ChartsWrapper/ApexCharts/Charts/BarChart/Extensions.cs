namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.BarChart;
public static class Extensions
{
    public static IBarChartOptionsBuilder CreateBarChart(this IChartOptionsBuilder builder, Dictionary<object, object> data)
    {
        return new BarChartOptionsBuilder(builder, data);
    }
}
