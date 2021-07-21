using System;

namespace FaultAlert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            ServiceProvider sp = new ACCServiceProvider();

            var alerts = sp.Update();

            var sender = new EmailSender();

            foreach (var alert in alerts)
            {
                sender.Send("alert", alert);
            }
            
        }
    }
}
