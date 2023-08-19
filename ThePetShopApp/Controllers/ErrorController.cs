namespace ThePetShopApp.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger _logger;
        public ErrorController(ILogger<ErrorController> looger)
        {
            _logger = looger;
        }
        public IActionResult Index()
        {
            _logger.LogError("There was an erorr");
            return View();
        }
    }
}
