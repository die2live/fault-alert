using System.Threading.Tasks;

namespace FaultAlert.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Fault Alert started!!!");

            while (true){
                ServiceProvider sp = new ACCServiceProvider();

                var alerts = sp.Update();

                var sender = new EmailSender();

                foreach (var alert in alerts)
                {
                    sender.Send("alert", alert);
                }
                await Task.Delay(5000);
            }
            
            
        }
    }
}
