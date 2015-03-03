using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.MessageService
{
    public class MessageHub : Hub<IMessageClient>
    {
        public void Send(object msg, params string[] userids)
        {
            if (userids == null || userids.Length == 0)
                Clients.Others.onReceiver(msg);
        }
    }
}
