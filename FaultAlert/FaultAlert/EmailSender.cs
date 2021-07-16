using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultAlert
{
    public class EmailSender : ISender
    {
        public bool Send(string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
