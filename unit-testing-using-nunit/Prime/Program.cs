
namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            if (candidate == 1)
            {
                return false;
            }
            if (candidate == 0){
                return true;
            }

            return true;

        }
    }
public class Program
   {
      public static void Main()
      {
         Console.WriteLine("Hello World!");
      }
   }
}

