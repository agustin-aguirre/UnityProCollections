using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ProCollections
{
	// Basically, a circular array
	public class Catalog<T> : IReadOnlyList<T>
	{
		protected T[] values;

		public Catalog()
			=> values = new T[0];

		public Catalog(T[] elements)
		{
			values = new T[elements.Length];
			elements.CopyTo(this.values, 0);
		}

		public Catalog(IEnumerable<T> elements)
		{
			values = new T[elements.Count()];
            int i = 0;
            foreach (var item in elements)
				values[i++] = item;
        }

		public virtual T this[int index]
		{
			get
			{
				int count = Count;
				var targetIndex = IndexTricks.CircularOffset(values.Length, 0, index);
				return values[targetIndex];
			}
		}

		public int Count => values.Length;

		public IEnumerator<T> GetEnumerator()
			=> values.Cast<T>().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> values.GetEnumerator();
	}
}