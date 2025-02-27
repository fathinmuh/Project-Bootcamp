using System;

struct Datadiri
{
    public string Nama, TTL;
    public int NIK;
    public Datadiri(string nama, int nik, string ttl)
    {
        Nama = nama;
        NIK = nik;
        TTL = ttl;
    }
}

class Program
{
    static void Main()
    {
        // Showhow person = new Showhow("turin", 123456789, "hitlum 4 desember 4012");
		Datadiri person = new Datadiri("turin", 123456789, "hitlum 4 desember 4012");
		Console.WriteLine($"Nama: {person.Nama}, NIK: {person.NIK}, TTL: {person.TTL}");
    }
}
