namespace Infrastructure
{
	public class BaseController : Microsoft.AspNetCore.Mvc.Controller
	{
		public BaseController() : base()
		{
		}

		public BaseController(Models.DatabaseContext databaseContext) : base()
		{
			_databaseContext = databaseContext;
		}

		private readonly Models.DatabaseContext _databaseContext;

		protected Models.DatabaseContext MyDatabaseContext
		{
			get
			{
				return (_databaseContext);
			}
		}
	}
}
