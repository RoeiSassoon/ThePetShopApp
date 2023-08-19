namespace ThePetShopApp.Controllers
{
    public class HomeController : Controller
    {
        IAnimalRepository _animalRepository { get; set; }
        public HomeController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
        public async Task<IActionResult> HomePage() => View(await _animalRepository.TwoMostRatedPets());
	
    }
}
