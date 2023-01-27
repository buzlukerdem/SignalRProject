using Microsoft.AspNetCore.SignalR;

namespace SignalRProject.Hubs
{
	public class MessageHub : Hub
	{
		public async Task SendMessageAsync(string message, string groupName)
		{
			#region Caller Kullanimi
			// sadece server'a bildirim gonderen client ile iletisim kurulur.
			//await Clients.Caller.SendAsync("receiveMessage", message);
			#endregion
			#region All Kullanimi
			//await Clients.All.SendAsync("receiveMessage", message);
			#endregion
			#region Others Kullanimi
			await Clients.Others.SendAsync("receiveMessage", message);
			#endregion

			await Clients.Group(groupName).SendAsync("receiveMessage", message);

		}

		public override async Task OnConnectedAsync()
		{
			// baglanti gerceklestiren client sadece kendisi connectionId'sini gorecektir.
			await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
		}

		public async Task addGroup(string connectionId, string groupName)
		{
			await Groups.AddToGroupAsync(connectionId, groupName);
		}
	}
}
