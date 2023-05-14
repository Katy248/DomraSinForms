using Newtonsoft.Json;

namespace DomraSinForms.ChartsWrapper.Models;

public class Chart
{
    public Chart(string elementId, string chartName, IEnumerable<object[]> dataTable, ChartOptions options)
    {
        var jsonSettings = new JsonSerializerSettings 
        { 
            NullValueHandling = NullValueHandling.Ignore,
        };
        var dataJson = JsonConvert.SerializeObject(dataTable, jsonSettings);
        var optionsJson = JsonConvert.SerializeObject(options, jsonSettings);
        var htmlValue = $$"""
            let data = google.visualization.arrayToDataTable(JSON.parse('{{dataJson}}'), true);
            let options = JSON.parse('{{optionsJson}}');
            let chart = new google.visualization.{{chartName}}(document.getElementById('{{elementId}}'));
            chart.draw(data, options);
            """;
        Value = htmlValue;
    }
    public string Value { get; set; }

    public static IEnumerable<object[]> GetDataTable(IQuestionSummary question)
    {
        foreach (var answer in question.Answsers.Distinct())
           yield return new object[] { answer, question.Answsers.Count() / question.Answsers.Where(a => a == answer).Count() * 100 };
    }
}
public enum ChartType
{
    PieChart,
}
