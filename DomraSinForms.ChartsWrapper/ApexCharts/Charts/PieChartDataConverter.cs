using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts.Charts;
public class PieChartDataConverter : IChartDataConverter
{
    public string ChartType => "pie";

    public Tuple<IEnumerable<object>, IEnumerable<object>> Convert(Dictionary<object, object> data)
    {
        throw new NotImplementedException();
    }
}
