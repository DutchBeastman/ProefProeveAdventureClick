using System;

namespace Utils
{
	public static class FloatExtensions
	{
		public static bool AlmostEquals(this float a , float b , float epsilon)
		{
			return Math.Abs(a - b) < epsilon;
		}
	}
}