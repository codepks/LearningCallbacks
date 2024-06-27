# Learning Callbacks in C#

# Delegates
```
class GFG { 

	// Declaring the delegate 
	public delegate int my_delegate(int s, int d, int f, int g); 

	// Method 
	public static int mymethod(int s, int d, int f, int g) 	{ 
		return s * d * f * g; 
	} 

	// Main method 
	static public void Main() 	{ 
		// Creating object of my_delegate 
		my_delegate obj = mymethod; 
		Console.WriteLine(obj(12, 34, 35, 34)); 
	} 
} 
```

Steps:
1. First declare a a custom delegate of some signature outside the main method
2. Create an object of the delegate



























# Learning Callbacks in C++
