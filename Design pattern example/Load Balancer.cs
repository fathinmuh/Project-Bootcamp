public sealed class LoadBalancer
{
    private static int Counter = 0;

    List<string> servers = new List<string>();
    Random random = new Random();
    private static LoadBalancer _instance;
    private static object _lock = new object();

    private LoadBalancer()
    {
        Counter++;
        Console.WriteLine("Counter Value load balancer " + Counter.ToString());

        servers.Add("Server1");
        servers.Add("Server2");
        servers.Add("Server3");
        servers.Add("Server4");
        servers.Add("Server5");
    }

    public static LoadBalancer GetLoadBalancer()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new LoadBalancer();
                }
            }
        }
        return _instance;
    }

    public string Server
    {
        get
        {
            int r = random.Next(servers.Count);
            return servers[r].ToString();
        }
    }
}