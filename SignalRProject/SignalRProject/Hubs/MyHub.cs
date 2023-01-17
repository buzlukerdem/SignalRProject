using Microsoft.AspNetCore.SignalR;
using SignalRProject.Interfaces;

namespace SignalRProject.Hubs
{
	public class MyHub:Hub<IHubFunc>
	{
		static List<string> clients = new List<string>();	

		// baglanma durumu
		public override async Task OnConnectedAsync()
		{
			clients.Add(Context.ConnectionId);
			await Clients.All.Clients(clients);
			await Clients.All.UserJoined(Context.ConnectionId);
		}
		// baglanti kopma durumu
		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			clients.Remove(Context.ConnectionId);
			await Clients.All.Clients(clients);
			await Clients.All.UserLeaved(Context.ConnectionId);
		}
	}
}
