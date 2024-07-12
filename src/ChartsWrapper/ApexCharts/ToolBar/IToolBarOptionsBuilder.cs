namespace DomraSinForms.ChartsWrapper.ApexCharts.ToolBar;
public interface IToolBarOptionsBuilder
{
    IToolBarOptionsBuilder EnableTool(ToolBarTool tool, string? customClass = null);
    IToolBarOptionsBuilder Show(bool show = true);
    ToolBarOptions Build();
}
