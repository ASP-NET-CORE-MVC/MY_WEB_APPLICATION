namespace MY_WEB_APPLICATION.Controllers
{
	public class HomeController : Infrastructure.BaseController
	{
		public HomeController() : base()
		{
		}

		public Microsoft.AspNetCore.Mvc.IActionResult Index()
		{
			return (View());
		}

		public Microsoft.AspNetCore.Mvc.IActionResult About()
		{
			ViewData["Message"] =
				"Your application description page.";

			return (View());
		}

		public Microsoft.AspNetCore.Mvc.IActionResult Contact()
		{
			ViewData["Message"] =
				"Your contact page.";

			return (View());
		}

		public Microsoft.AspNetCore.Mvc.IActionResult Error()
		{
			return (View(new ViewModels.ErrorViewModel
			{ RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
		}
	}
}
