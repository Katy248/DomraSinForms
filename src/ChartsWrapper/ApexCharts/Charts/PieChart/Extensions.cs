namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts.PieChart;
public static class Extensions
{
    public static IPieChartOptionsBuilder CreatePieChart(this IChartOptionsBuilder builder, Dictionary<object, object> data)
    {
        return new PieChartOptionsBuilder(builder, data);
    }
}
