using Microsoft.AspNetCore.SignalR;
using SignalRProject.Hubs;

namespace SignalRProject.Business
{
	public class MyHubBusiness
	{
		readonly IHubContext<MyHub> _hubContext;

		public MyHubBusiness(IHubContext<MyHub> hubContext)
		{
			_hubContext = hubContext;
		}

		public async Task SendMessageAsync(string message)
		{
			await _hubContext.Clients.All.SendAsync("receiveMessage", message);
		}
	}
}
