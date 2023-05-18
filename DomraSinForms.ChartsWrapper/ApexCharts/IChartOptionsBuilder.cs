namespace DomraSinForms.ChartsWrapper.ApexCharts;
public interface IChartOptionsBuilder
{
    internal ChartOptions IntermediateInstance { get; }
    ChartOptions Build();
}
