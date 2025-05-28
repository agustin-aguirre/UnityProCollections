using System;
using System.Collections;
using System.Collections.Generic;


namespace ProCollections
{
	public class History<T> : IEnumerable<T>, IReadOnlyCollection<T> where T : notnull
	{
		Stack<T> values;

		public History(T firstValue)
		{
			values = new Stack<T>();
			values.Push(firstValue);
		}

		public History(IEnumerable<T> orderedValues)
			=> values = new Stack<T>(orderedValues);


		public int Count => values.Count;

		public void CopyTo(Array array, int index)
			=> values.CopyTo((T[])array, index);

		public virtual T Peek()
			=> values.Peek();

		public virtual T Pop()
			=> values.Count > 1 ? values.Pop() : Peek();

		public virtual void Push(T value)
			=> values.Push(value);

		public virtual void Push(IEnumerable<T> orderedValues)
		{
			foreach (T value in orderedValues)
				values.Push(value);
		}

		public virtual void Clear()
		{
            while(values.Count > 1)
				values.Pop();
        }


		public IEnumerator GetEnumerator()
			=> values.GetEnumerator();

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
			=> values.GetEnumerator();
	}
}