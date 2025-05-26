namespace ProCollections
{
	public class IndexTricks
	{
		public static int CircularNext(int totalElements, int currentIndex, int offset = 1)
			=> (currentIndex + System.Math.Abs(offset)) % totalElements;

		public static int CircularPrevious(int totalElements, int currentIndex, int offset = 1)
			=> (currentIndex + totalElements - System.Math.Abs(offset)) % totalElements;

		public static int CircularOffset(int totalElements, int currentIndex, int offset)
			=> pythonicModulus((currentIndex + offset), totalElements);


		private static int pythonicModulus(float dividend, float divisor)
			=> (int)dividend - UnityEngine.Mathf.FloorToInt(dividend / divisor) * (int)divisor;
	}
}
