# Learning Callbacks in C#

# Delegates
1. With delegatDelegates allow functions to be passed as parameters, returned from a function as a value, and stored in an array
2. Delegates, you can treat a function as data.
3. They have a signature and a return type. A function that is added to delegates must be compatible with this signature
4. Once a delegate object has been created, it may invoke the methods it points to at runtime.
5. Delegates can call methods synchronously and asynchronously.
6. invoking a delegate syntactically is the exact same as calling a regular function



## Example 1
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
4. Note: In order to invoke the function you just need to pass the function name and no parameters along

## Example 2
[Tim Corey](https://www.youtube.com/watch?v=R8Blt5c-Vi4&ab_channel=IAmTimCorey)
Product structure
```
namespace DelegatesnEvents
{
    public struct Product
    {
        public string ItemName;
        public double ItemPrice;
    }
}
```

Shopping Cart
```
namespace DelegatesnEvents
{
     internal class ShoppingCartModel
 {

     public List<Product>? CartProducts { get; set; } = new List<Product>();

     public delegate void FinalPriceDel(double price);

     public ShoppingCartModel() { }

      //Getting this function logic to main class intead
/* public double GeneratePrice()
 {
     double sumTotal = CartProducts.Sum(x => x.ItemPrice);

     double finalPrice = 0.0;
     if (sumTotal > 90)
     {
         finalPrice =  sumTotal * 0.9;
     }
     else if (sumTotal > 50)
     {
         finalPrice = sumTotal * 0.7;
     }

     return finalPrice;
 }*/

 /*public double GeneratePrice(FinalPriceDel funcDel)
 {
     double sumTotal = CartProducts.Sum(x => x.ItemPrice);
     //since our main class function returns double, we will return the double too here from the function callback
     return funcDel(sumTotal);
 }*/

 public double GeneratePrice(Func<double,double> funcDel)
 {
     double sumTotal = CartProducts.Sum(x => x.ItemPrice);
     
     return  funcDel(sumTotal);
 }
 }
}
```
Main class 
```
namespace DelegatesnEvents
{
    internal class Program
    {
        static void AddItemsToCart(ShoppingCartModel shoppingCartModel)
        {
            shoppingCartModel.CartProducts?.Add(new Product { ItemName = "Nimbu", ItemPrice = 20 });
            shoppingCartModel.CartProducts?.Add(new Product { ItemName = "Mirchi", ItemPrice = 30 });
            shoppingCartModel.CartProducts?.Add(new Product { ItemName = "Dhaniya", ItemPrice = 15 });
            shoppingCartModel.CartProducts?.Add(new Product { ItemName = "Gochi", ItemPrice = 25 });
        }

        static void Main(string[] args)
        {
            ShoppingCartModel shoppingCartModel = new ShoppingCartModel();

            AddItemsToCart(shoppingCartModel);

            Console.WriteLine($"Effective card price is {shoppingCartModel.GenerateFinalPrice(FinalPrice)}"); ;
            
        }

        static void FinalPrice(double sumTotal)
        {
            //The sumTotal comes from the callback
	    //It works because you pass the address of the function to be invoked 
            if (sumTotal > 90) {
                Console.WriteLine($"final price is {sumTotal * 0.9}"); }
            else if (sumTotal > 50) { 
                Console.WriteLine($"final price is {sumTotal * 0.7}"); }

        }
    }
}
```


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

# Generic Delegate - Action
Action delegates return void and thereby it can be used for alerts
Main Class
```
  static void Main(string[] args)
  {
      ShoppingCartModel shoppingCartModel = new ShoppingCartModel();

      AddItemsToCart(shoppingCartModel);

      Console.WriteLine($"Effective card price is {shoppingCartModel.GeneratePrice(FinalPrice, AlertCall)}"); ;
      
  }

  .
  .
  .

  private static void AlertCall(string message)
  {
      Console.WriteLine(message);
  }
```

Shopping Cart
```
.
.
public double GeneratePrice(Func<double,double> funcDel, Action<string> alertAction)
{
    double sumTotal = CartProducts.Sum(x => x.ItemPrice);

    alertAction("Generating discout for you");		//We decide here to invoke alert here with a string here

    return  funcDel(sumTotal);
}
```


## Self Learning
### Advantage 1
1. In general, we try to invoke 2nd party function B from our 1st party function A
2. This way only function A is in our control but the 2nd/3rd has the control over **what** to invoke and **when** to invoke
3. But we use delegates, we have control over both function A and function B, the only control 2md/3rd party would have is over **when** to invoke it
4. All we need to do is to pass the function name and it will take it and decide when to invoke it

### Adanvtage 2
1. Today we might be invoking a function of some signature
2. Tomorrow we can pass some other function name with same signature too

Steps:
1. No need for creating a separate delegate in Func and ACtion
2. Associate your function name with the Func generic delegate knowing the input parameter and output  parameter
3. Input parameter being the initial parameters and output being the last one

## Theory
[source](https://www.c-sharpcorner.com/UploadFile/84c85b/delegates-and-events-C-Sharp-net/)

1. Callback is generally used for one function to report back to another function in an application
2. Objective of callback is handle button clicking , menu selection and mouse moving activities
3. Issue : It is not type sage

# Anoanymous Methods
It is not a delegate, rather defining your own anonymous short function on top of the already passed delegates to a function
```
//Passing methods to get invoked
 Console.WriteLine($"Effective cart price is {shoppingCartModel.GeneratePrice(FinalPrice, AlertCall)}"); ;

 Console.WriteLine(); 

//Utilizing the function and signature to pass your own short functions or may be extending functionalities
 Console.WriteLine($"Effective cart price 2 is {shoppingCartModel.GeneratePrice((sumTotal) =>
 {
     if(sumTotal > 70) { return  sumTotal*0.6; }
     return 0;
 },
     (message) => Console.WriteLine($"Generating Discount v2 {message}")) }") ;
```

# Button and Events
In winform UI functions are subscribed to buttons click events liek this:
```
this.someButton.Click += new System.EventsHAndler(this.someButton_Click);
```

# Eventsk

[source](https://www.youtube.com/watch?v=-1cftB9q1kQ&ab_channel=IAmTimCorey)

# IObservable





















# Learning Callbacks in C++
