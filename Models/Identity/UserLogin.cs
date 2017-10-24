/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class UserLogin :
		Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public UserLogin() : base()
		{
		}

		// **********
		public virtual User User { get; set; }
		// **********
	}
}
