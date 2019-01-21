using System;

namespace Monte_Carlo_Pi_Approximation
{
	public static class TSRandom
	{
		private static readonly Random random = new Random();
		[ThreadStatic] private static Random localRandom;

		public static double NextDouble() {
			if (localRandom == null) {
				int seed;
				lock (random) seed = random.Next();
				localRandom = new Random(seed);
			}

			return localRandom.NextDouble();
		}
	}
}
