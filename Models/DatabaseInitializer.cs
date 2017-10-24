using System.Linq;

namespace Models
{
	public static class DatabaseInitializer
	{
		static DatabaseInitializer()
		{
		}

		public static void Initialize(DatabaseContext databaseContext)
		{
			databaseContext.Database.EnsureCreated();

			// Look for any test posts.
			if (databaseContext.PostCategories.Any())
			{
				// Database has been seeded!
				return;
			}

			// **************************************************
			Cms.PostCategory postCategory = null;

			postCategory =
				new Cms.PostCategory() { Code = 1, Name = "اخبار" };

			databaseContext.PostCategories.Add(postCategory);

			postCategory =
				new Cms.PostCategory() { Code = 2, Name = "آموزش" };

			databaseContext.PostCategories.Add(postCategory);
			// **************************************************

			databaseContext.SaveChanges();
		}
	}
}
