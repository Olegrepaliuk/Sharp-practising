using System;
public class Student
{
	private string name;
	public string Name { 
		get { return name; } 
		set {
				if (value ==  null) throw new ArgumentException();
				name = value; 
			} 
	}
}
public class Test
{
	public static void Main()
	{
		
        var book = new Book();
	    book.Title = "Structure and interpretation of computer programs";
	    Console.WriteLine(book.Title);
		
	}
}

public class Book
{
    private string title;
	public string Title{
        get {return title;}
        set {title = value;}
    }
}
public class Vector
{
	public double X{get; set;}
	public double Y{get; set;}
	public double Length{
        get{return X*Y;}
    }

    public Vector (double x, double y)
    {
        X = x;
        Y = y;
    }

	

	public override string ToString()
	{
		return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
	}
}
public class Ratio
{
	public Ratio(int num, int den)
	{
        if (den<=0) 
		{
			throw new ArgumentException();
		}	
		Numerator = num;
        Denominator = den;
        Value = (double)Numerator/Denominator;
	}
    
	public readonly int Numerator; 
	public readonly int Denominator;
        
	public readonly double Value; 
}