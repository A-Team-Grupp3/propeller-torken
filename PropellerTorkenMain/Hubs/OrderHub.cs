using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PropellerTorkenMain.Hubs
{
    public class OrderHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("RecieveMessage", message);
        }
    }
}