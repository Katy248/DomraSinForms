using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.ChartsWrapper
{
    public class Row : IEnumerable<Object>
    {
        public Row(int capacity = 2)
        {
            Items = new(capacity);
        }
        public readonly List<Object> Items;
        public IEnumerator<object> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator ();
        }
    }
}
