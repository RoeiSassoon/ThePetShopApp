namespace ThePetShopApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private PetShopContext petDb;
        private DbSet<Animal> _animals;
        private DbSet<Comment> _comments;

        public AnimalRepository(PetShopContext petShopContext)
        {
            petDb = petShopContext;
            _animals = petDb.Animals;
            _comments = petDb.Comments;
        }
        public async Task<List<Animal>> ShowAllAnimals() => await _animals.ToListAsync();

        public async Task<List<Animal>> TwoMostRatedPets() =>
           await _animals.Where(e => e.Comments != null).Include(a => a.Comments).OrderByDescending(a => a.Comments!.Count()).Take(2).ToListAsync();
   

        public async Task<Animal> GetAnimalAsync(int id) => 
      await _animals.Where(e => e.Id == id).Include(a => a.Comments).Include(a => a.Category).FirstAsync();

        public  async Task<List<Animal>> SerachByCatagoryId(int catagoryId) => await  _animals.Where(e => e.CategoryId == catagoryId).ToListAsync();
		public async Task AddComment(Comment comment)
        {
			await _comments.AddAsync(comment);
			await petDb.SaveChangesAsync();
		}
        public async Task DeleteComment(int idCooment)
        {
            var comment = await _comments.SingleAsync(e => e.Id == idCooment);
            _comments.Remove(comment);
            await petDb.SaveChangesAsync();
        }
        public async Task DeleteAnimal(int id)
        {
            var animal = await _animals.SingleAsync(a => a.Id == id);
            var comments = await _comments.Where(c => c.AnimalId == id).ToListAsync();
            foreach (var comment in comments)
            {
                _comments.Remove(comment);
            }
            _animals.Remove(animal);
            await petDb.SaveChangesAsync();
        }
        public async Task<Category> CatgoryName(int id)
        {
            return await petDb.Categories.SingleAsync(e => e.CategoryId == id);
        }
        public async Task AddAnimal(Animal animal)
        {
           await _animals.AddAsync(animal);
            await petDb.SaveChangesAsync();
        }
        public async Task EditAnimal(Animal animal)
        {
            var myAnimal= await _animals.SingleAsync(e => e.Id == animal.Id);
            myAnimal.Name = animal.Name;
            myAnimal.Age = animal.Age;
            myAnimal.Description = animal.Description;
            myAnimal.CategoryId = animal.CategoryId;
            myAnimal.PictureName = animal.PictureName;
			await petDb.SaveChangesAsync();
		}

		public  async Task<List<Category>> GetCategories()
		{
            return await petDb.Categories.ToListAsync();
		}
	}
}
