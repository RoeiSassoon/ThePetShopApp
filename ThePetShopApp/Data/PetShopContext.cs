namespace ThePetShopApp.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Birds" },
            new Category { CategoryId = 2, Name = "Mammals" },
            new Category { CategoryId = 3, Name = "Fish" });
            
            Animal deer = new Animal { Id = 1, Name = "Deer", Age = 5,  Description = "Deer, (family Cervidae), any of 43 species of hoofed ruminants in the order Artiodactyla, notable for having two large and two small hooves on each foot and also for having antlers in the males of most species and in the females of one species.", CategoryId = 2,  PictureName= "/img/deer.png" };
            Animal eagle = new Animal { Id = 2, Name = "Eagle", Age = 3, Description= "Eagles have extremely powerful vision. The eyes of an eagle are specially designed for long-distance focus with clarity. The eagle's eye is one of the strongest in the entire animal kingdom (four to eight times stronger than that of the average human). An eagle is able to spot a rabbit 3.2 km away.", CategoryId = 1, PictureName= "/img/eagle.png" };
            Animal elephant = new Animal { Id = 3, Name = "Elephant", Age = 3, Description= "they are highly intelligent animals with complex emotions, feelings, compassion and self-awareness (elephants are one of very few species to recognize themselves in a mirror!). The gestation period of an elephant is 22 months. That's almost 2 years, the longest pregnancy of any mammal!", CategoryId = 2, PictureName= "/img/elephant.png" };
            Animal giraffe = new Animal { Id = 4, Name = "Giraffe", Age = 3, Description= "The tallest land mammal, with a neck as long as 6 feet, the giraffe is also well known for the unique brown and white pattern on its coat (“pelage”) and its lengthy eyelashes and legs. Habitat: Giraffes use both semi-arid savannah and savannah woodlands in Africa", CategoryId = 2, PictureName= "/img/giraffe.png" };
			Animal clownfish = new Animal { Id = 5, Name = "Clownfish", Age = 1, Description = "Clownfish are small, brightly colored fish that are known for forming symbiotic relationships with sea anemones. They are popular aquarium fish and are characterized by their bright orange color with white stripes.", CategoryId = 3, PictureName = "/img/clownfish.png" };

			Animal angelfish = new Animal{Id = 6,Name = "Angelfish",Age = 20,
				Description = "Angelfish are a type of freshwater fish known for their distinctive shape and graceful movements. They come in various colors and patterns and are commonly kept in aquariums.",
				CategoryId = 3,
				PictureName = "/img/angelfish.png"
			};

			Animal salmon = new Animal
			{
				Id = 7,
				Name = "Salmon",
				Age = 3,
				Description = "Salmon are iconic migratory fish found in both freshwater and saltwater. They are known for their ability to navigate long distances upstream to spawn in their natal rivers. Salmon are a prized food fish and are also important for maintaining ecosystems.",
				CategoryId = 3,
				PictureName = "/img/salmon.png"
			};

			Animal goldfish = new Animal
			{
				Id = 8,
				Name = "Goldfish",
				Age = 12,
				Description = "Goldfish are a popular and common freshwater fish that belong to the carp family. They are known for their bright colors and are one of the first fish species to be domesticated and kept as pets.",
				CategoryId = 3,
				PictureName = "/img/goldfish.png"
			};

			Animal guppy = new Animal
			{
				Id = 9,
				Name = "Guppy",
				Age = 7,
				Description = "Guppies are small, colorful, and easy-to-care-for freshwater fish. They are popular among aquarium enthusiasts for their lively nature and ability to breed easily.",
				CategoryId = 3,
				PictureName = "/img/guppy.png"
			};
			Animal sparrow = new Animal
			{
				Id = 10,
				Name = "Sparrow",
				Age = 11,
				Description = "Sparrows are small, common birds found in various habitats around the world. They have a distinctive brown and gray plumage and are known for their cheerful chirping sounds.",
				CategoryId = 1,
				PictureName = "/img/sparrow.png"
			};

			modelBuilder.Entity<Animal>().HasData(deer, eagle, elephant, giraffe, clownfish, angelfish, salmon, goldfish, guppy, sparrow);

            List<Comment> comments = new List<Comment> {new Comment { Id = 1, Description = "He is a יפה\r\nיפה\r\n3 / 5,000\r\nTranslation results\r\nTranslation result\r\nBeautiful\r\n" ,AnimalId=1} ,
      new Comment { Id = 2, Description = "He is easy to find",AnimalId=1 },
      new Comment{ Id = 3, Description = "Very fasy" ,AnimalId=2},
      new Comment{ Id = 4, Description = "Hard to find" ,AnimalId=2},
      new Comment{ Id = 5, Description = "I'm too short to see his head",AnimalId=4 } };

            modelBuilder.Entity<Comment>().HasData(comments);


      

        }

    }
}
