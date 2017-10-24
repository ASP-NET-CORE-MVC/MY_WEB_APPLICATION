namespace Models.Cms
{
	[System.ComponentModel.DataAnnotations.Schema.Table
		(name: "PostCategories", Schema = Constants.SCHEMA_NAME)]
	public class PostCategory : BaseEntity
	{
		public PostCategory() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.Code))]
		public int Code { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.Name))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 100)]
		public string Name { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.Description))]
		public string Description { get; set; }
		// **********
	}
}
