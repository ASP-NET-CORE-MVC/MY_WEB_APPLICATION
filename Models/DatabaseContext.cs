//namespace Models
//{
//	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
//	{
//		//static DatabaseContext()
//		//{
//		//}

//		//public DatabaseContext() : base()
//		//{
//		//}

//		public DatabaseContext
//			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
//		{
//		}

//		public Microsoft.EntityFrameworkCore.DbSet<Cms.PostCategory> PostCategories { get; set; }

//		protected override void OnModelCreating
//			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
//		{
//			base.OnModelCreating(modelBuilder);
//		}
//	}
//}

namespace Models
{
	public class DatabaseContext :
		Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<Identity.User, Identity.Role, System.Guid, Identity.UserClaim, Identity.UserRole, Identity.UserLogin, Identity.RoleClaim, Identity.UserToken>
	//, IUnitOfWork
	{
		public DatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public Microsoft.EntityFrameworkCore.DbSet<Cms.PostCategory> PostCategories { get; set; }

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
