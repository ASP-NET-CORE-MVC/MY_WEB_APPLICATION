/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class UserRole :
		Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public UserRole() : base()
		{
		}

		// **********
		public virtual User User { get; set; }
		// **********

		// **********
		public virtual Role Role { get; set; }
		// **********
	}
}
