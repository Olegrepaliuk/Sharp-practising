	class Program
	{
		
		public static void Main(string[] args)
		{
			Func<int, int, int, int>f = (x, y, z) => x * y + z;
			var x0 = f(1, 2, 3);
			var x1 = Apply1(f, 100)(1, 11);
			
			var g = Apply2(Apply1(f, 10), 5);
			var x2 = g(3);

			Console.ReadKey();
		}
		
		private static Func<int, int, int> Apply1(Func<int, int, int, int> func, int arg)
		{
			return (x, y) => func(x, arg, y);
		}

		private static Func<int, int> Apply2(Func<int, int, int> func, int arg)
		{
			return x => func(arg, x);
		}
		
		private static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> filter)
		{
			foreach(var e in source)
				if(filter(e))
					return e;
			return default(T);
		}
		
		private static IEnumerable<T> Take<T>(IEnumerable<T> source, int count)
		{
			if (count == 0)
				yield break;
			foreach (var e in source)
			{
				yield return e;
				if(--count==0)
					yield break;
			}
		}

		public static int[] ParseNumbers(IEnumerable<string> lines)
		{
			return lines
				.Where(s => !string.IsNullOrEmpty(s))
				.Select(s => int.Parse(s))
				.ToArray();
		}

		public static List<Point> ParsePoints(IEnumerable<string> lines)
		{
			return lines
				.Select(z => z.Split())
				.Select(z => z
						.Select(x => int.Parse(x))
						.ToArray()
						)
				.Select(z => new Point(z[0], z[1]))
				.ToList();
		}
	}