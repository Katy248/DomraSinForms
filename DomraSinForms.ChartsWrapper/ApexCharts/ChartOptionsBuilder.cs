namespace DomraSinForms.ChartsWrapper.ApexCharts;
public class ChartOptionsBuilder : IChartOptionsBuilder
{
    protected ChartOptions _options = new();
    public ChartOptions IntermediateInstance => _options;
    public ChartOptionsBuilder UsePalette(int paletteNumber)
    {
        if (paletteNumber >= 0 | paletteNumber <= 10)
        {
            _options.Theme.Palette = $"palette{paletteNumber}";
        }
        return this;
    }
    public ChartOptions Build()
    {
        return _options;
    }
}