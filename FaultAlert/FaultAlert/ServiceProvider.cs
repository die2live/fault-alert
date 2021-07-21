using System;
using System.Collections.Generic;

namespace FaultAlert
{
    public abstract class ServiceProvider : IServiceProvider
    {
        public string Name { get; set; }

        public abstract List<string> Update();
   
    }
}
