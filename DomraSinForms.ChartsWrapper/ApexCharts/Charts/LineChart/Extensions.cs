namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.LineChart;
public static class Extensions
{
    public static ILineChartOptionsBuilder CreateLineChart(this IChartOptionsBuilder builder, Dictionary<object, object> data, LineChartDataType type = LineChartDataType.Line)
    {
        return new LineChartOptionsBuilder(builder, data, type);
    }
}
