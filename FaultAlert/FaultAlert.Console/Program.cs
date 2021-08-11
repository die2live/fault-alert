using System;

namespace FaultAlert.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while(true){
                Console.WriteLine("Hello World!");

                ServiceProvider sp = new ACCServiceProvider();

                var alerts = sp.Update();

                var sender = new EmailSender();

                foreach (var alert in alerts)
                {
                    sender.Send("alert", alert);
                }
                await Task.Delay(500);
            }
            
            
        }
    }
}
