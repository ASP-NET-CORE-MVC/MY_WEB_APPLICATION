using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MY_WEB_APPLICATION.Areas.Cms.Controllers
{
	[Microsoft.AspNetCore.Mvc.Area(areaName: "Cms")]
	public class PostCategoriesController : Infrastructure.BaseController
	{
		public PostCategoriesController(Models.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ViewResult> Index()
		{
			var postCategories =
				await
				MyDatabaseContext.PostCategories
				.OrderBy(current => current.Code)
				.ToListAsync()
				;

			return (View(model: postCategories));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (NotFound());
			}

			Models.Cms.PostCategory postCategory =
				await
				MyDatabaseContext.PostCategories
				.FirstOrDefaultAsync(current => current.Id == id.Value);

			if (postCategory == null)
			{
				return (NotFound());
			}

			return (View(model: postCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public Microsoft.AspNetCore.Mvc.ViewResult Create()
		{
			// **************************************************
			Models.Cms.PostCategory
				defaultPostCategory = new Models.Cms.PostCategory();
			// **************************************************

			return (View(model: defaultPostCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		[Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> Create
			([Microsoft.AspNetCore.Mvc.Bind("Code,Name,Description")] Models.Cms.PostCategory postCategory)
		{
			if (ModelState.IsValid)
			{
				MyDatabaseContext.Add(postCategory);

				await MyDatabaseContext.SaveChangesAsync();

				return (RedirectToAction(actionName: nameof(Index)));
			}

			return (View(model: postCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (NotFound());
			}

			Models.Cms.PostCategory postCategory =
				await
				MyDatabaseContext.PostCategories
				.FirstOrDefaultAsync(m => m.Id == id.Value);

			if (postCategory == null)
			{
				return (NotFound());
			}

			return (View(model: postCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		[Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> Edit
			(System.Guid id, [Microsoft.AspNetCore.Mvc.Bind("Code,Name,Description,Id")]
			Models.Cms.PostCategory postCategory)
		{
			// **************************************************
			if (postCategory.Id != id)
			{
				return (NotFound());
			}

			Models.Cms.PostCategory originalPostCategory =
				await
				MyDatabaseContext.PostCategories
				.FirstOrDefaultAsync(m => m.Id == id);

			if (postCategory == null)
			{
				return (NotFound());
			}
			// **************************************************

			if (ModelState.IsValid)
			{
				try
				{
					originalPostCategory.Code = postCategory.Code;
					originalPostCategory.Name = postCategory.Name;
					originalPostCategory.Description = postCategory.Description;

					await MyDatabaseContext.SaveChangesAsync();
				}
				catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
				{
					return (NotFound());
				}

				return (RedirectToAction(actionName: nameof(Index)));
			}

			return (View(model: postCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (NotFound());
			}

			Models.Cms.PostCategory postCategory =
				await MyDatabaseContext.PostCategories
				.FirstOrDefaultAsync(m => m.Id == id.Value);

			if (postCategory == null)
			{
				return (NotFound());
			}

			return (View(model: postCategory));
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		[Microsoft.AspNetCore.Mvc.ActionName("Delete")]
		[Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> DeleteConfirmed(System.Guid? id)
		{
			Models.Cms.PostCategory postCategory =
				await MyDatabaseContext.PostCategories
				.FirstOrDefaultAsync(m => m.Id == id.Value);

			MyDatabaseContext.PostCategories.Remove(postCategory);

			await MyDatabaseContext.SaveChangesAsync();

			return (RedirectToAction(actionName: nameof(Index)));
		}
	}
}
