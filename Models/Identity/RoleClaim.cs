/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class RoleClaim :
		Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public RoleClaim() : base()
		{
		}

		// **********
		public virtual Role Role { get; set; }
		// **********
	}
}
