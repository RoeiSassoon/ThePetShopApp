

namespace ThePetShopApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="please enter your comment")]
        [MaxLength(200,ErrorMessage ="Too Long")]
        public string? Description { get; set; }
        [Required()]
        [Range(1,100, ErrorMessage ="Out of range(1-100)")]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
