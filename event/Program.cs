public class Stock
{
    // Declare a sealed event
    public sealed event EventHandler PriceChanged;

    // Method to trigger the event
    public void ChangePrice(decimal newPrice)
    {
        PriceChanged?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main()
    {
        Stock stock = new Stock();
        stock.PriceChanged += (sender, e) => Console.WriteLine("Price changed!");
        
        // Trigger the event
        stock.ChangePrice(200m);
    }
}