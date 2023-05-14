using System.Text;
using DomraSinForms.ChartsWrapper.Models;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Wrappers;
public class Wrapper
{
    private List<HtmlString> Charts = new();

    public HtmlString Init()
    {
        var value = """
            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
            """;
        return new HtmlString(value);
    }
    public HtmlString WriteCharts()
    {
        var builder = new StringBuilder();
        foreach (var chart in Charts)
        {
            builder.Append(chart.Value);
        }
        return new HtmlString(builder.ToString());
    }
    public HtmlString Chart(string elementId, IQuestionSummary model, ChartOptions options)
    {
        var fn = "drawChartNo" + model.Question.Index;
        var value = $$"""
            <script>
            google.charts.load('current', { 'packages': ['corechart'] });
                google.charts.setOnLoadCallback({{fn}});
                function {{fn}} () {
                    {{GetPieChart(elementId, PieChart.GetDataTable(model), options)}}
                }
            </script>
            """;
        return new HtmlString(value);
    }
    public void AddChart(string elementId, IQuestionSummary model, ChartOptions options)
    {
        Charts.Add(Chart(elementId, model, options));
    }
    public string GetPieChart(string elementId, IEnumerable<object[]> dataTable, ChartOptions options)
    {
        var dataJson = JsonConvert.SerializeObject(dataTable);
        var optionsJson = JsonConvert.SerializeObject(options);
        var htmlValue = $$"""
            let data = google.visualization.arrayToDataTable(JSON.parse('{{dataJson}}'), true);
            let options = JSON.parse('{{optionsJson}}');
            let chart = new google.visualization.PieChart(document.getElementById('{{elementId}}'));
            chart.draw(data, options);
            """;
        return htmlValue;
    }
}
