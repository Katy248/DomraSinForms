namespace DomraSinForms.ChartsWrapper.Models;
public class PieChart
{
    public static IEnumerable<object[]> GetDataTable(IQuestionSummary question)
    {
        var answersPercents = new List<object[]>();
        foreach (var answer in question.Answsers.Distinct())
        {
            answersPercents.Add(new object[] { answer, question.Answsers.Count() / question.Answsers.Where(a => a == answer).Count() * 100});
        }
        return answersPercents;
    }
}
