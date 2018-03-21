namespace Delegate
{
	public delegate void TellUser(string str);
	class Program
	{
		public static void Main(string[] args)
		{
			Run(Console.WriteLine);
			Console.ReadKey();		
		}
		static void Run(TellUser tellUser)
		{
			tellUser("Hi");
			tellUser("Hello");
		}
	}
	public delegate bool TryGet<T1,T2>(string str, Action<string> action, out int age);
	class NewClass
	{
		static void Act()
		{
			Run(AskUser, Console.WriteLine);
		}
		static void Run(TryGet<string, int> askUser, Action<string> tellUser)
		{
			int age;
			if(askUser("What is your age?", tellUser, out age))
			tellUser("Age: " + age);
		}
		static bool AskUser(string questionText, Action<string> tellUser, out int age)
		{
			tellUser(questionText);
			var answer = Console.ReadLine();
			return int.TryParse(answer, out age);
		}
	}


	//Lambda expressions

	private static readonly Func<int> zero = () => 0;
	private static readonly Func<int, string> toString = (x) => Convert.ToString(x); 
	private static readonly Func<double, double, double> add = (x,y) => x+y;
	private static readonly Action<string, string> print = (str) => Console.WriteLine(str);


	Func<int, int> doubleValue = x => 2 * x;
	Func<int, int> minusOne = x => x - 1;
	var f2 = Combine(minusOne, doubleValue);
	Console.WriteLine(f2(2)); // 2
	Console.WriteLine(f2(5)); // 8

	static Func<T1, T3> Combine<T1, T2, T3>(Func<T1, T2> f, Func<T2, T3> g)
	{
		return x => g(f(x));
	}

}