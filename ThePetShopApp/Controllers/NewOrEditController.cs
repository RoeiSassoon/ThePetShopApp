namespace ThePetShopApp.Controllers
{
	public class NewOrEditController : Controller
	{

		IAnimalRepository _animalRepository { get; set; }
		private FileService FileService { get; }

		public NewOrEditController(IAnimalRepository animalRepository, FileService fileService)
		{
			_animalRepository = animalRepository;
			FileService = fileService;
		}

		public async Task<IActionResult> AddEditPage(int id)
		{
			var categories = await _animalRepository.GetCategories();
			ViewBag.Categories = categories;
			if (id == 0)
			{
				ViewBag.Method = "AddAnimal";
				return View(new Animal());
			}
			else
			{
				ViewBag.Method = "EditAnimal";
				return View(await _animalRepository.GetAnimalAsync(id));
			}
		}
		public async Task<IActionResult> AddAnimal( Animal animal )
		{
			if(animal.ImageFile != null)
			{ animal.PictureName = FileService.UploadToWebRoot(animal.ImageFile); }
			
			if (ModelState.IsValid)
			{
				await _animalRepository.AddAnimal(animal);
				return RedirectToAction("AdminPage", "Admin");
			}
			else
			{
				return RedirectToAction("AddEditPage");

			}
		}
		public async Task<IActionResult> EditAnimal(Animal animal)
		{

			if (animal.ImageFile != null)
			{ animal.PictureName = FileService.UploadToWebRoot(animal.ImageFile); }

			if (ModelState.IsValid)
			{
				await _animalRepository.EditAnimal(animal);

				return RedirectToAction("AdminPage", "Admin");
			}
			else
			{
				ViewBag.Error = "Please check tour input";
				return RedirectToAction("AddEditPage", new { id = animal.Id});
			}
		}
	}
}
