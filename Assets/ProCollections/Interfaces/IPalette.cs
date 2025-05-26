using System.Collections.Generic;


namespace ProCollections.Interfaces
{
	public interface IPalette<out T> : IReadOnlyList<T>
	{
		int Index { get; set; }
		T Selected { get; }
		int OffsetFromZero { get; }
		T ElementAtOffset(int offset);
		void MoveIndex(int offset);
	}
}
