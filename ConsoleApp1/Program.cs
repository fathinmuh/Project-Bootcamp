class Tiket
{
	private int _price;
    private int nomertiket=123;
    private int nomertiket2=666;
	public Tiket(int price)
	{
		if (!(price < 100))
		{
			Environment.Exit(0);
		}
	}

	public int CheckVariable(string validasi)
	{
        Console.Write("nomer tiket: ");
		if(validasi.Equals("fathin"))
		{
			return nomertiket;
		}
        else if(validasi.Equals("muhammad"))
		{
			return nomertiket2;
		}
		return 0;
	}
	//fuction overide
	public virtual void Greating()
	{
		Console.WriteLine("Total =");
	}
	
	//fucn untuk mengubah nilai dengan valiadsi
	protected void SetPrice(int price)
	{
		if (!(price < 0))
		{
			this._price = price;
		}
	}
}

class Order:Tiket
{
    
    private int harga1=25000;
    private int harga2=20000;
	public string skill;
	public Order(int _price, string skill):base(_price)
	{
		this.skill = skill;
	}
	//modifier public acces protected acces private
	public void SetPricePublic(int price)
	{
		SetPrice(price);
	}
	
	//Overide
	public override void Greating()
	{
		base.Greating();
		Console.WriteLine("Selamat datang lagi"); 
	}
	
}

class Program 
{
	static void Main()
	{
        Console.Write("OTP (2 digit): ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.Write("nama: ");
        string nama = Console.ReadLine();

		Tiket tiket = new Tiket(number);
		
		Order order= new Order(number, nama);
		Console.WriteLine(order.CheckVariable(nama));
		
        Console.Write("Jumlah tiket: ");
        int Jumlah = Convert.ToInt32(Console.ReadLine());
		order.SetPricePublic(Jumlah);
		
		//ovveride
		order.Greating();
	}
}

﻿
