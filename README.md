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
2. Create an object of the delegate and initialize it `my_delegate obj = mymethod;`
3. Call the delegate to invoke the function `obj(12, 34, 35, 34)`

# Generic Delegate - Func
```
class GFG { 
      // Method 
    public static int method(int num)     { 
        return num + num; 
    } 
  
    // Main method 
    static public void Main()    { 
  
        // Using Func delegate 
        // Here, Func delegate contains  
        // the one parameters of int type 
        // one result parameter of int type 
        Func<int, int> myfun = method; 
        Console.WriteLine(myfun(10)); 
    } 
}
```

Steps:
1. No need for creating a separate delegate
2. Associate your function name with the Func generic delegate knowing the input parameter and output  parameter
3. Input parameter being the initial parameters and output being the last one

























# Learning Callbacks in C++
