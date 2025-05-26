using ProCollections.Interfaces;
using System;
using System.Collections.Generic;


namespace ProCollections
{
	// A Catalog (wich is a Circular array), but with a selected object
	public class Palette<T> : Catalog<T>, IObservablePalette<T>, IReadOnlyList<T>
	{
		int index = 0;

		public int Index
		{
			get => index;
			set
			{
				if (value == index) return;
				index = IndexTricks.CircularOffset(Count, 0, value);
				OnIndexChanged?.Invoke(index);
				OnSelectedElementChanged?.Invoke(Selected);
				OnSelectionChanged?.Invoke(index, Selected);
			}
		}

		public event Action<int, T> OnSelectionChanged;
		public event Action<int> OnIndexChanged;
		public event Action<T> OnSelectedElementChanged;

		public Palette() : base() { }
		
		public Palette(IEnumerable<T> items) : base(items) { }

		public T Selected => this[index];

		public int OffsetFromZero => offsetIndex(Index);

		public void MoveIndex(int offset) => Index = offsetIndex(offset);

		public T ElementAtOffset(int offset) => this[index + offset];

		protected int offsetIndex(int offset) => IndexTricks.CircularOffset(Count, Index, offset);
	}
}