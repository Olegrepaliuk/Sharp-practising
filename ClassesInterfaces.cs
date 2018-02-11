using System;

public class Point
{
    	public double X;
	public double Y;
	public override string ToString()
	{
		return string.Format("{0} {1}", X, Y);
	}
}

public class Triangle
{
	public Point A;
	public Point B;
	public Point C;
	public override string ToString()
	{
		return string.Format("Треугольник с координатами: {0} {1} {2}", A, B, C);
	}
}

public class ClockwiseComparer : IComparer
{
	public int Compare(object x, object y)
	{
		var firObj = (Point)x;
		var secObj = (Point)y;
		if((firObj.X.CompareTo(secObj.X)==0)&(firObj.Y.CompareTo(secObj.Y)==0))
		{
			return 0;
		}
		
	}
}

public class Book : IComparable
{
	public string Title;
	public int Theme;
	
	public int CompareTo(object obj)
	{
		var secArg = (Book) obj;
		if ((Title.CompareTo(secArg.Title)==0)&(Theme.CompareTo(secArg.Theme)==0))
		{
			return 0;
		}
		if (Theme.CompareTo(secArg.Theme)!=0)
		{
			return Theme.CompareTo(secArg.Theme);
		}
		else
		{
			return Title.CompareTo(secArg.Title);
		}	
	}	
}
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var ints = new[] { 1, 2 };
	    	var strings = new[] { "A", "B" };

	   	Print(Combine(ints, ints));
	    	Print(Combine(ints, ints, ints));
	    	Print(Combine(ints));
	    	Print(Combine());
	    	Print(Combine(strings, strings));
	    	Print(Combine(ints, strings));
		
		
		Console.WriteLine(MiddleOfThree(2, 5, 4));
		Console.WriteLine(MiddleOfThree(3, 1, 2));
		Console.WriteLine(MiddleOfThree(3, 5, 9));
		Console.WriteLine(MiddleOfThree("B", "Z", "A"));
		Console.WriteLine(MiddleOfThree(3.45, 2.67, 3.12));
		
		
		
		//Console.WriteLine(Min(2,4,10,151,5));
	    
	    	Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
	    	Console.WriteLine(Min(new[] { '4', '2', '7' }));
		
	
	}
	public static void Print(Array array)
    {
	    if (array == null)
	    {
		    Console.WriteLine("null");
		    return;
	    }
	for (int i = 0; i < array.Length; i++)
		Console.Write("{0} ", array.GetValue(i));
	Console.WriteLine();
    }
	
	
	public static Array Combine(params Array[] arrays) {
	if (arrays.Length == 0)
		return null;
	var type = arrays[0].GetType().GetElementType();
	var length = 0;
	foreach (var array in arrays) {
		if (array.GetType().GetElementType() != type)
			return null;
		length += array.Length;
	}
	
	var result = Array.CreateInstance(type, length);
	var index = 0;
	foreach (var array in arrays)
		foreach (var elem in array)
			result.SetValue(elem, index++);
	return result;
	}
	public static IComparable MiddleOfThree(params IComparable[] array)
		{
			Array.Sort(array);
			return array[1];
		}
	public static object Min(Array array)
	{
		Array.Sort(array);
		return array.GetValue(0);
	}
	

}
