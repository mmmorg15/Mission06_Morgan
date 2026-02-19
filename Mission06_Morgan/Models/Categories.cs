using System.ComponentModel.DataAnnotations;

namespace Mission06_Morgan.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
    }
}
