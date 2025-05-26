using System;


namespace ProCollections.Interfaces
{
	public interface IObservablePalette<out T> : IPalette<T>
	{
		public event Action<int> OnIndexChanged;
		public event Action<T> OnSelectedElementChanged;
		public event Action<int, T> OnSelectionChanged;
	}
}
