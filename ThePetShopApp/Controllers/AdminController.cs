namespace ThePetShopApp.Controllers
{
	public class AdminController : Controller
	{

		IAnimalRepository _animalRepository { get; set; }
		public AdminController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
		public async Task<IActionResult> AdminPage(int id)
		{
            ViewBag.Mothod = "AdminPage";
			if (id == 0)
			{
				ViewBag.Catgory = "Select catgory:";
				return View(await _animalRepository.ShowAllAnimals());
			}
			else
			{
				var category = await _animalRepository.CatgoryName(id);

				ViewBag.Catgory = category.Name;
				return View(await _animalRepository.SerachByCatagoryId(id));
			}
		}

		public async Task<IActionResult> DeleteAnimal(int id)
		{
			await _animalRepository.DeleteAnimal(id);
			return RedirectToAction("AdminPage");
		}
    }
}
