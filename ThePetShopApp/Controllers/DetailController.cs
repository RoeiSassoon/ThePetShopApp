namespace ThePetShopApp.Controllers
{
	public class DetailController : Controller
	{

		IAnimalRepository _animalRepository { get; set; }
		public DetailController(IAnimalRepository animalRepository) => _animalRepository = animalRepository;
		public async Task<IActionResult> DetailPage(int Id)
		{
			ViewBag.Animal = await _animalRepository.GetAnimalAsync(Id);
			return View();
		}

		public async Task<IActionResult> AddComment(Comment comment)
		{
			if (ModelState.IsValid)
			{
				await _animalRepository.AddComment(comment);
				
			}
			
			return RedirectToAction("DetailPage", new { Id = comment.AnimalId });

		}

		public async Task<IActionResult> DeleteComment(int idAnimal, int idComment)
		{
			await _animalRepository.DeleteComment(idComment);
			return RedirectToAction("DetailPage", new { Id = idAnimal });
		}
	}
}
