namespace MauiScaling.Extensions
{
	public static class MathExtensions
	{
        public static bool IsEqualTo(this float a, float b)
        {
            return Math.Abs(a - b) < double.Epsilon;
        }
    }
}