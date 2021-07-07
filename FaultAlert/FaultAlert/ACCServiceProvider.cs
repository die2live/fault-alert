using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultAlert
{
    class ACCServiceProvider : ServiceProvider
    {
        public Uri BaseSerivceUri { get; set; }

        public ACCServiceProvider()
        {
            this.Name = "ACC";
            this.BaseSerivceUri = new Uri("https://acc.md/disconnections");
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }

        public void GetUnplannedDisconnections()
        {
            
        }
    }
}
