using System.Collections;

namespace DomraSinForms.ChartsWrapper.Models
{
    public class Row : IEnumerable<object>
    {
        public Row(int capacity = 2)
        {
            Items = new(capacity);
        }
        public readonly List<object> Items;
        public IEnumerator<object> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
