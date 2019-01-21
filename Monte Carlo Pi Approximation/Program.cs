using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Carlo_Pi_Approximation
{
	class Program
	{
		private const double center = 0.5d;
		private const double centerSqr = center * center;

		private static void Main() {
			//Keep reading input
			while (true) {
				//Get an int from the user
				bool numeric = int.TryParse(Console.ReadLine(), out int passes);

				if (!numeric) {
					Console.WriteLine("Please enter an integer!");
					continue;
				}

				//Let them know in case they forget.. or.. something.
				Console.WriteLine("Calculating...");

				//Start a stopwatch so we can keep track of how long it takes
				Stopwatch sw = Stopwatch.StartNew();

				//Calculate pi
				double pi = CalculatePi(passes);

				//Stop the stopwatch
				sw.Stop();

				//Report the output back
				Console.WriteLine($"Pi ({passes:n0} passes): {pi}");
				Console.WriteLine($"Took: {Math.Round(sw.ElapsedMilliseconds / 1000d, 3)}s");
			}
		}

		private static double CalculatePi(int passes) {
			int amountInCircle = 0;

			//Go through our passes and generate points
			Parallel.For(0, passes, i => {
				//Generate random x and y coordinates
				double x = TSRandom.NextDouble();
				double y = TSRandom.NextDouble();

				//Add to the circle count if it's in the circle
				if (IsInCircle(x, y))
					Interlocked.Increment(ref amountInCircle);
			});

			return amountInCircle * 4d / passes;
		}

		private static bool IsInCircle(double x, double y) {
			//Calculate the 2d distance between the point and the center point
			double xc = x - center;
			double yc = y - center;

			//Check if it's within the radius of the circle
			return xc * xc + yc * yc <= centerSqr;
		}
	}
}
