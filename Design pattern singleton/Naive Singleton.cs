namespace SingletonPattern
{
    public sealed class Singleton
    {
        private Singleton() { } // konstruktor singleton privat
        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine("Hello singleton! ");
        }
    }
}