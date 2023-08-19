namespace ThePetShopApp.Repositories
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> TwoMostRatedPets();
        Task<List<Animal>> ShowAllAnimals();
        Task<Animal> GetAnimalAsync(int id);
		Task AddComment(Comment comment);
		Task DeleteComment(int id);
        Task DeleteAnimal(int id);

        Task<List<Animal>> SerachByCatagoryId(int catagoryId);
        Task<Category> CatgoryName(int id);
       Task AddAnimal(Animal animal);
        Task<List<Category>> GetCategories();
        Task EditAnimal(Animal animal);

	}
}
