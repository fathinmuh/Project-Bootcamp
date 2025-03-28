using System;
namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call the GetInstance static method to get the Singleton Instance
            Singleton fromTeachaer = Singleton.GetInstance();
            fromTeachaer.PrintDetails("From Teacher");

            //Call the GetInstance static method to get the Singleton Instance
            Singleton fromStudent = Singleton.GetInstance();
            fromStudent.PrintDetails("From Student");

            Console.ReadLine();
        }
    }
}