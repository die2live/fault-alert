using System;

namespace FaultAlert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            ServiceProvider sp = new ACCServiceProvider();

            sp.Update();
        }
    }
}
