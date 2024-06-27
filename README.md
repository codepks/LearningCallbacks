# Learning Callbacks in C#

# Delegates

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
     public double GenerateFinalPrice(FinalPriceDel finalPriceDel)
     {
         double sumTotal = CartProducts.Sum(x => x.ItemPrice);

         finalPriceDel(sumTotal);

         //if (sumTotal > 90)
         //{
         //    Console.WriteLine($"final price is {sumTotal * 0.9}");
         //}
         //else if (sumTotal > 50)
         //{
         //    Console.WriteLine($"final price is {sumTotal * 0.7}");
         //}

         return 0;
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
1. No need for creating a separate delegate
2. Associate your function name with the Func generic delegate knowing the input parameter and output  parameter
3. Input parameter being the initial parameters and output being the last one



# IObservable





















# Learning Callbacks in C++
