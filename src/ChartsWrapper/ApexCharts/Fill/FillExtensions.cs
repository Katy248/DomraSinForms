namespace DomraSinForms.ChartsWrapper.ApexCharts.Fill;

public static class FillExtensions
{
    public static TOptions WithFill<TOptions>(this TOptions options, Action<FillOptions> fillAction) where TOptions : ChartOptionsBuilder
    {
        fillAction.Invoke(options.IntermediateInstance.Fill);
        return options;
    }
    public static TOptions ShowGrid<TOptions>(this TOptions options, bool showGrid = true) where TOptions : ChartOptionsBuilder
    {
        options.IntermediateInstance.Grid.Show = showGrid;
        return options;
    }
}
