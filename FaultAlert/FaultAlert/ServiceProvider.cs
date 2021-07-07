using System;


namespace FaultAlert
{
    public abstract class ServiceProvider : IServiceProvider
    {
        public string Name { get; set; }

        public abstract bool Update();
   
    }
}
