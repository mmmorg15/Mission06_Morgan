using System.ComponentModel.DataAnnotations;

namespace Mission06_Morgan.Models
{
    // This class represents the model for the categories in the application. 
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
    }
}
