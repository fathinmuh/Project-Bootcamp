using System;

interface IKendaraan
{
    void HidupkanMesin();
    void MatikanMesin();
    void TampilkanInfo();
    void KodeNomer();
}

class Mobil : IKendaraan
{
    public string Merk { get; set; }
    public string Model { get; set; }
    public int TahunProduksi { get; set; }
    public string PlatNomer{ get;set; }

    public Mobil(string merk, string model, int tahun, string plat)
    {
        Merk = merk;
        Model = model;
        TahunProduksi = tahun;
        PlatNomer = plat;
    }

    public void HidupkanMesin()
    {
        Console.WriteLine($"Mobil {Merk} {Model} hidup!");
    }

    public void MatikanMesin()
    {
        Console.WriteLine($"Mobil {Merk} {Model} mati!");
    }

    public void TampilkanInfo()
    {
        Console.WriteLine($"Mobil: {Merk} {Model}, Tahun: {TahunProduksi}");
    }

    public void KodeNomer()
    {
        Console.WriteLine($"Mobil: {Merk} {Model}, Plat: {PlatNomer}");
    }    
}

class Program
{
    static void Main()
    {
        IKendaraan mobil = new Mobil("Toyota", "Avanza", 2022, "AE-3887-LO");

        mobil.TampilkanInfo();
        mobil.HidupkanMesin();
        mobil.MatikanMesin();
        mobil.KodeNomer();

        Console.WriteLine();
    }
}

