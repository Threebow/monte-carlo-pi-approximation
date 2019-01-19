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

				//Calculate pi
				double pi = CalculatePi(passes);

				//Print it out
				Console.WriteLine(pi);
			}
		}

		private static double CalculatePi(int passes) {
			//Create an array of our two-dimensional points
			var points = new Point[passes];

			//Go through our passes and generate points
			for (int i = 0; i < passes; i++) {
				//Generate random x and y coordinates
				double x = rand.NextDouble();
				double y = rand.NextDouble();

				//Insert them into the two-dimensional array
				points[i] = new Point(x, y);
			}

			//Count how many points landed in the circle
			int amountInCircle = points.Count(IsInCircle);
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