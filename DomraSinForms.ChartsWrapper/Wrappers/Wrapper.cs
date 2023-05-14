using System.Reflection;
using System.Text;
using DomraSinForms.ChartsWrapper.Models;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Wrappers;
public class Wrapper
{
    private List<Chart> Charts = new();

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
            var fn = "drawChartNo" + int.Abs(chart.Value.GetHashCode());
            builder.Append($"<script>" +
                $"google.charts.load('current', {{ 'packages': ['corechart'] }});" +
                $"google.charts.setOnLoadCallback({fn});" +
                $"function {fn} (){{ {chart.Value} }}" +
                $"</script>");
        }
        return new HtmlString(builder.ToString());
    }
    public HtmlString Chart1(string elementId, IQuestionSummary model, ChartOptions options)
    {
        var fn = "drawChartNo" + model.Question.Index;
        var value = $$"""
            <script>
            google.charts.load('current', { 'packages': ['corechart'] });
                google.charts.setOnLoadCallback({{fn}});
                function {{fn}} () {
                    {{GetPieChart(elementId, Chart.GetDataTable(model), options)}}
                }
            </script>
            """;
        return new HtmlString(value);
    }
    /*public void AddChart(string elementId, IQuestionSummary model, ChartOptions options)
    {
        Charts.Add(Chart1(elementId, model, options));
    }*/
    public void AddChart(Chart chart)
    {
        Charts.Add(chart);
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
