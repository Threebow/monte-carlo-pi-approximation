using System;
using System.Linq;
using System.Windows;

namespace Monte_Carlo_Pi_Approximation
{
	class Program
	{
		private static readonly Random rand = new Random();
		private static readonly Point center = new Point(0.5f, 0.5f);

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
				if (IsInCircle(new Point(x, y)))
					amountInCircle++;
			}

			return amountInCircle * 4d / passes;
		}

		private static bool IsInCircle(Point point) {
			//Calculate the 2d distance between the point and the center point
			double distance = Point.Subtract(point, center).Length;

			//Check if it's within the radius of the circle
			return distance <= 0.5d;
		}
	}
}