public class Stock
{
    private decimal price;
    public virtual event EventHandler PriceChanged;
    public decimal Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                var oldPrice = price;
                price = value;
                OnPriceChanged(new EventArgs());
            }
        }
    }

    protected virtual void OnPriceChanged(EventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
}

public class SpecialStock : Stock
{
    public override event EventHandler PriceChanged;
    protected override void OnPriceChanged(EventArgs e)
    {
        Console.WriteLine("Price changed in SpecialStock!");
        base.OnPriceChanged(e);
    }
}

class Program
{
    static void Main()
    {
        SpecialStock stock = new SpecialStock();
        stock.PriceChanged += (sender, e) => Console.WriteLine("Subscriber received price change notification.");
        stock.Price = 150m;
    }
}