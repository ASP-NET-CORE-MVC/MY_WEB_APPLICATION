/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// http://www.dotnettips.info/post/2559
/// </summary>

namespace Models.Identity
{
	public class User :
		Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>,
		AuditableEntity.IAuditableEntity
	{
		public User() : base()
		{
			UserTokens =
				new System.Collections.Generic.HashSet<UserToken>();

			//UserUsedPasswords =
			//	new System.Collections.Generic.HashSet<UserUsedPassword>();
		}

		// **********
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50)]
		public string FirstName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 450)]
		public string LastName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public string DisplayName
		{
			get
			{
				var displayName =
					$"{FirstName} {LastName}";

				return (string.IsNullOrWhiteSpace(displayName) ? UserName : displayName);
			}
		}
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 250)]
		public string PhotoFileName { get; set; }
		// **********

		// **********
		public System.DateTimeOffset? BirthDate { get; set; }
		// **********

		// **********
		public System.DateTimeOffset? CreatedDateTime { get; set; }
		// **********

		// **********
		public System.DateTimeOffset? LastVisitDateTime { get; set; }
		// **********

		// **********
		public bool IsEmailPublic { get; set; }
		// **********

		// **********
		public string Location { set; get; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<UserRole> Roles { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<UserClaim> Claims { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<UserLogin> Logins { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.ICollection<UserToken> UserTokens { get; set; }
		// **********

		// **********
		//public virtual System.Collections.Generic.ICollection<UserUsedPassword> UserUsedPasswords { get; set; }
		// **********
	}
}
