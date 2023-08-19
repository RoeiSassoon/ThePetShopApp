
namespace ThePetShopApp.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please enther the animal name")]
        [MaxLength(30,ErrorMessage ="Too long,Max is 30 charecthers")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "please please enther age of the animal")]
        [Range(1,300,ErrorMessage ="age mast be btw 1-300")]
        public int Age { get; set; }
        public string? PictureName { get; set; }
        [Required(ErrorMessage ="Please enter discrption")]
        [MaxLength(300,ErrorMessage ="Max reached please enter less then 300 char . ")]
        public string? Description { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        [Required(ErrorMessage ="please choosed a catgory")]
        [Range(1,100,ErrorMessage ="out of catgories range")]
        public  int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
