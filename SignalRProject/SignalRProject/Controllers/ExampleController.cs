using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.Business;

namespace SignalRProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExampleController : ControllerBase
	{
		readonly MyHubBusiness _myHubBusiness;

		public ExampleController(MyHubBusiness myHubBusiness)
		{
			_myHubBusiness = myHubBusiness;
		}
		[HttpGet("{message}")]
		public async Task<ActionResult> Index(string message)
		{
			await _myHubBusiness.SendMessageAsync(message);
			return Ok();
		}
	}
}
