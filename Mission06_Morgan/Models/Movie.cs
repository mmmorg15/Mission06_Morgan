using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Morgan.Models
{
    // This class represents the model for the movie form in the application. It contains properties that correspond to the fields in the form, such as MovieID, Category, Title, Year, Director, Rating, Edited, LentTo, and Notes. The properties are decorated with data annotations to specify validation rules and requirements for each field
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category {  get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Please enter a valid year after 1888")]
        public int Year { get; set; }

        
        public string? Director { get; set; }
      
        public string? Rating { get; set; }
        [Required]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
