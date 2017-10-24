/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// </summary>

namespace Models.Identity
{
	public class Role : Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>, AuditableEntity.IAuditableEntity
	{
		public Role() : base()
		{
		}

		//public Role(string name) : this()
		//{
		//	Name = name;
		//}

		//public Role(string name, string description) : this(name)
		//{
		//	Description = description;
		//}

		// **********
		public string Description { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<UserRole> Users { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<RoleClaim> Claims { get; set; }
		// **********
	}
}
