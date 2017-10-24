/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class UserToken :
		Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public UserToken() : base()
		{
		}

		// **********
		public virtual User User { get; set; }
		// **********
	}
}
