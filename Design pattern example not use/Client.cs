public class Client
{
    private LoadBalancer balancer;

    public Client()
    {
        // Setiap Client memiliki instance LoadBalancer sendiri (tidak berbagi)
        balancer = new LoadBalancer();
    }

    public void RequestServer()
    {
        string server = balancer.GetServer();
        Console.WriteLine($"Client request directed to: {server}");
    }
}
