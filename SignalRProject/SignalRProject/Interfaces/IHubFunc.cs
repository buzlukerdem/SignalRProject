namespace SignalRProject.Interfaces
{
	public interface IHubFunc
	{
		Task Clients(List<string> clients);
		Task UserJoined(string connectionId);
		Task UserLeaved(string connectionId);
	}
}
