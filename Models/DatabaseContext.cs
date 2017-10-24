namespace Models
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		//static DatabaseContext()
		//{
		//}

		//public DatabaseContext() : base()
		//{
		//}

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
