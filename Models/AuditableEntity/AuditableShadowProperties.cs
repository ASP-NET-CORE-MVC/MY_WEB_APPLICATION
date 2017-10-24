using System.Linq;

/// <summary>
/// http://www.dotnettips.info/post/2577
/// http://www.dotnettips.info/post/2578
/// http://www.dotnettips.info/post/2507
/// http://www.dotnettips.info/post/2232
/// </summary>

namespace ASPNETCoreIdentitySample.Entities.AuditableEntity
{
	public static class AuditableShadowProperties
	{
		public static readonly System.Func<object, string>
			EFPropertyCreatedByBrowserName = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<string>(entity, CreatedByBrowserName);

		public static readonly string CreatedByBrowserName = nameof(CreatedByBrowserName);

		public static readonly System.Func<object, string>
			EFPropertyModifiedByBrowserName = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<string>(entity, ModifiedByBrowserName);

		public static readonly string ModifiedByBrowserName = nameof(ModifiedByBrowserName);

		public static readonly System.Func<object, string>
			EFPropertyCreatedByIp = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<string>(entity, CreatedByIp);

		public static readonly string CreatedByIp = nameof(CreatedByIp);

		public static readonly System.Func<object, string>
			EFPropertyModifiedByIp = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<string>(entity, ModifiedByIp);

		public static readonly string ModifiedByIp = nameof(ModifiedByIp);

		public static readonly System.Func<object, int?>
			EFPropertyCreatedByUserId = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<int?>(entity, CreatedByUserId);

		public static readonly string CreatedByUserId = nameof(CreatedByUserId);

		public static readonly System.Func<object, int?>
			EFPropertyModifiedByUserId = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<int?>(entity, ModifiedByUserId);

		public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

		public static readonly System.Func<object, System.DateTimeOffset?>
			EFPropertyCreatedDateTime = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<System.DateTimeOffset?>(entity, CreatedDateTime);

		public static readonly string CreatedDateTime = nameof(CreatedDateTime);

		public static readonly System.Func<object, System.DateTimeOffset?>
			EFPropertyModifiedDateTime = entity =>
			Microsoft.EntityFrameworkCore.EF.Property<System.DateTimeOffset?>(entity, ModifiedDateTime);

		public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);

		public static void AddAuditableShadowProperties
			(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			foreach (var entityType in modelBuilder.Model
				.GetEntityTypes()
				.Where(e => typeof(Models.AuditableEntity.IAuditableEntity).IsAssignableFrom(e.ClrType)))
			{
				modelBuilder.Entity(entityType.ClrType)
					.Property<string>(CreatedByBrowserName).HasMaxLength(1000);

				modelBuilder.Entity(entityType.ClrType)
					.Property<string>(ModifiedByBrowserName).HasMaxLength(1000);

				modelBuilder.Entity(entityType.ClrType)
					.Property<string>(CreatedByIp).HasMaxLength(255);

				modelBuilder.Entity(entityType.ClrType)
					.Property<string>(ModifiedByIp).HasMaxLength(255);

				modelBuilder.Entity(entityType.ClrType)
					.Property<int?>(CreatedByUserId);

				modelBuilder.Entity(entityType.ClrType)
					.Property<int?>(ModifiedByUserId);

				modelBuilder.Entity(entityType.ClrType)
					.Property<System.DateTimeOffset?>(CreatedDateTime);

				modelBuilder.Entity(entityType.ClrType)
					.Property<System.DateTimeOffset?>(ModifiedDateTime);
			}
		}

		/// <summary>
		/// More info: http://www.dotnettips.info/post/2507
		/// </summary>
		public static void SetAuditableEntityPropertyValues
			(this Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker changeTracker,
			Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
		{
			var httpContext = httpContextAccessor?.HttpContext;
			var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();
			var userIp = httpContext?.Connection?.RemoteIpAddress?.ToString();

			var now = System.DateTimeOffset.UtcNow;
			//var userId = getUserId(httpContext);

			var modifiedEntries = changeTracker.Entries<Models.AuditableEntity.IAuditableEntity>()
				.Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified);

			foreach (var modifiedEntry in modifiedEntries)
			{
				modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
				modifiedEntry.Property(ModifiedByBrowserName).CurrentValue = userAgent;
				modifiedEntry.Property(ModifiedByIp).CurrentValue = userIp;
				//modifiedEntry.Property(ModifiedByUserId).CurrentValue = userId;
			}

			var addedEntries = changeTracker.Entries<Models.AuditableEntity.IAuditableEntity>()
				.Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added);

			foreach (var addedEntry in addedEntries)
			{
				addedEntry.Property(CreatedDateTime).CurrentValue = now;
				addedEntry.Property(CreatedByBrowserName).CurrentValue = userAgent;
				addedEntry.Property(CreatedByIp).CurrentValue = userIp;
				//addedEntry.Property(CreatedByUserId).CurrentValue = userId;
			}
		}

		//private static int? getUserId(Microsoft.AspNetCore.Http.HttpContext httpContext)
		//{
		//	int? userId = null;

		//	var userIdValue =
		//		httpContext?.User?.Identity?.GetUserId();

		//	if (string.IsNullOrWhiteSpace(userIdValue) == false)
		//	{
		//		userId = int.Parse(userIdValue);
		//	}

		//	return userId;
		//}
	}
}
