namespace Delegate20170709
{
    public class Program
    {
        static void Main(string[] args)
        {
            Looper looper = new Looper(1, 100, n => n % 2 == 0 );
            looper.Display();
        }
    }
}
