public class Client
{
    public void RequestServer()
    {
        LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
        string server = balancer.Server;
        Console.WriteLine($"Client request directed to: {server}");
    }
}
