using System;

namespace Monte_Carlo_Pi_Approximation
{
	class Program
	{
		private static readonly Random rand = new Random();
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

				//Calculate pi
				double pi = CalculatePi(passes);

				//Print it out
				Console.WriteLine($"Pi ({passes:n0} passes): {pi}");
			}
		}

		private static double CalculatePi(int passes) {
			int amountInCircle = 0;

			//Go through our passes and generate points
			for (int i = 0; i < passes; i++) {
				//Generate random x and y coordinates
				double x = rand.NextDouble();
				double y = rand.NextDouble();

				//Add to the circle count if it's in the circle
				if (IsInCircle(x, y))
					amountInCircle++;
			}

			return amountInCircle * 4d / passes;
		}

		private static bool IsInCircle(double x, double y) {
			//Calculate the 2d distance between the point and the center point
			double distance = (x-center)*(x-center)+(y-center)*(y-center);

			//Check if it's within the radius of the circle
			return distance <= centerSqr;
		}
	}
}
