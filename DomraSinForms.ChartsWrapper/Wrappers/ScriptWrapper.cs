using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.ChartsWrapper.Models;
using Microsoft.AspNetCore.Html;

namespace DomraSinForms.ChartsWrapper.Wrappers;
public class ScriptWrapper
{
    private List<string> _scripts = new();
    public HtmlString Init(string script)
    {
        return new HtmlString(script);
    }

    public void Add(string script)
    {
        _scripts.Add(script);
    }
    public HtmlString WriteAll()
    {
        return new HtmlString(string.Concat(_scripts.ToArray()));
    }
}
