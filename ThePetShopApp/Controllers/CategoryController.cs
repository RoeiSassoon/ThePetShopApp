namespace ThePetShopApp.Controllers
{
	public class CategoryController : Controller
	{

		IAnimalRepository _animalRepository { get; set; }
		public CategoryController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
		public async Task<IActionResult> CatalogPage(int id)
		{
			ViewBag.Mothod = "CatalogPage";
			if (id == 0)
			{
				ViewBag.Catgory = "Select catfory:";
				return View( await _animalRepository.ShowAllAnimals());
			}
			else
			{
				var category = await _animalRepository.CatgoryName(id);

				ViewBag.Catgory = category.Name;
				return View(await _animalRepository.SerachByCatagoryId(id));
			}

		}

	}
}
