using System;
namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static int Counter = 0;

        private static Singleton Instance = null;

        public static Singleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }

            return Instance;
        }

       //konstruktor private
        private Singleton()
        {
            Counter++;
            Console.WriteLine("Counter Value " + Counter.ToString());
        }

        //The following can be accesed from outside of the class by using the Singleton Instance
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}