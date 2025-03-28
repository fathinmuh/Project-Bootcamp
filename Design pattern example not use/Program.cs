using System;

public class Program
{
    public static void Main(string[] args)
    {
        Client client1 = new Client();
        Client client2 = new Client();
        Client client3 = new Client();

        

        client1.RequestServer();
        client2.RequestServer();
        client3.RequestServer();
    }
}

