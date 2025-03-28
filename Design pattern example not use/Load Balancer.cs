public class LoadBalancer
{
    private static int Counter = 0;
    private List<string> servers = new List<string>();
    private Random random = new Random();

    public LoadBalancer()
    {
        Counter++;
        Console.WriteLine("Counter Value load balancer " + Counter.ToString());
        servers.Add("ServerI");
        servers.Add("ServerII");
        servers.Add("ServerIII");
        servers.Add("ServerIV");
        servers.Add("ServerV");
    }

    public string GetServer()
    {
        int r = random.Next(servers.Count);
        return servers[r];
    }
}
