using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper.ApexCharts;
public class OptionsBuilder
{
    private readonly Options _options = new();
    public OptionsBuilder AddData<TChartDataConverter>(Dictionary<object, object> data, string seriesName = "") where  TChartDataConverter : IChartDataConverter, new()
    {
        var converter = new TChartDataConverter();
        var (series, categories) = converter.Convert(data);

        _options.Series.Add(new Series { Data = series, Name = seriesName });
        _options.XAxis.Categories = categories;
        _options.Chart.Type = converter.ChartType.ToLower();

        return this;
    }
    public OptionsBuilder UsePalette(int paletteNumber)
    {
        if (paletteNumber >= 0 | paletteNumber <= 10)
        {
            _options.Theme.Palette = $"palette{paletteNumber}";
        }
        return this;
    }
    public Options Build()
    {
        return _options;
    }
}

public interface IChartDataConverter
{
    Tuple<IEnumerable<object>, IEnumerable<object>> Convert(Dictionary<object, object> data);
    public string ChartType { get; }
}