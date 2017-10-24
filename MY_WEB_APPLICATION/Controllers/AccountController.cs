namespace MY_WEB_APPLICATION.Controllers
{
	public class AccountController : Infrastructure.BaseController
	{
		public AccountController() : base()
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public Microsoft.AspNetCore.Mvc.ViewResult Login()
		{
			return (View());
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		[Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
		public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>
			Login(ViewModels.Account.LoginViewModel viewModel, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			//if (ModelState.IsValid)
			//{
			//	var user =
			//		await _userManager.FindByNameAsync(viewModel.Username).ConfigureAwait(false);

			//	if (user == null)
			//	{
			//		ModelState.AddModelError
			//			(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");

			//		return (View(viewModel));
			//	}

			//	if (user.IsActive == false)
			//	{
			//		ModelState.AddModelError
			//			(string.Empty, "اکانت شما غیرفعال شده‌است.");

			//		return (View(viewModel));
			//	}

			//	if (_siteOptions.Value.EnableEmailConfirmation &&
			//		!await _userManager.IsEmailConfirmedAsync(user).ConfigureAwait(false))
			//	{
			//		ModelState.AddModelError
			//			(string.Empty, "لطفا به پست الکترونیک خود مراجعه کرده و ایمیل خود را تائید کنید!");

			//		return (View(viewModel));
			//	}

			//	var result =
			//		await
			//		_signInManager.PasswordSignInAsync(
			//			viewModel.Username,
			//			viewModel.Password,
			//			viewModel.RememberMe,
			//			lockoutOnFailure: true)
			//			.ConfigureAwait(false);

			//	if (result.Succeeded)
			//	{
			//		_logger.LogInformation(1, $"{viewModel.Username} logged in.");

			//		if (Url.IsLocalUrl(returnUrl))
			//		{
			//			return Redirect(returnUrl);
			//		}

			//		return (RedirectToAction(nameof(HomeController.Index), "Home"));
			//	}

			//	if (result.RequiresTwoFactor)
			//	{
			//		return RedirectToAction
			//			(nameof(TwoFactorController.SendCode),
			//			"TwoFactor",
			//			new { ReturnUrl = returnUrl, RememberMe = viewModel.RememberMe });
			//	}

			//	if (result.IsLockedOut)
			//	{
			//		_logger.LogWarning(2, $"{viewModel.Username} قفل شده‌است.");

			//		return (View("~/Areas/Identity/Views/TwoFactor/Lockout.cshtml"));
			//	}

			//	if (result.IsNotAllowed)
			//	{
			//		ModelState.AddModelError
			//			(string.Empty, "عدم دسترسی ورود.");

			//		return (View(viewModel));
			//	}

			//	ModelState.AddModelError
			//		(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");

			//	return (View(viewModel));
			//}

			//// If we got this far, something failed, redisplay form
			//return (View(viewModel));

			return (null);
		}
	}
}
