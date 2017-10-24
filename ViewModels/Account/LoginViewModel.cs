namespace ViewModels.Account
{
	public class LoginViewModel : object
	{
		public LoginViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.Username))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "(*)")]
		public string Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.Password))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "(*)")]

		[System.ComponentModel.DataAnnotations.DataType
			(System.ComponentModel.DataAnnotations.DataType.Password)]
		public string Password { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.Models.General),
			Name = nameof(Resources.Models.General.RememberMe))]
		public bool RememberMe { get; set; }
		// **********
	}
}
