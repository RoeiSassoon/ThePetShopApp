namespace ThePetShopApp.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("HomePage", "HomeController");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction();
        }
        public async void CreateAdmin()
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Administrators";
            await _roleManager.CreateAsync(role);

            IdentityUser admin = new IdentityUser
            {
                UserName = "Roei",
            };

            await _userManager.CreateAsync(admin, "123pass");
            await _userManager.AddToRoleAsync(admin, "Administrators");
        }

    }
}
