/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class UserClaim :
		Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public UserClaim() : base()
		{
		}

		// **********
		public virtual User User { get; set; }
		// **********
	}
}
