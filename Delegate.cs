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
}