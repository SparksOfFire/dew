using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.MessageService
{
    public interface IMessageClient
    {
        void onReceiver(object message);
    }
}
