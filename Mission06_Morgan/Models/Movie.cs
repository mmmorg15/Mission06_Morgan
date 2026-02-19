using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Morgan.Models
{
    
    public class Movie
    {
        // This class represents the model for the movies in the application. 
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

        [Required(ErrorMessage = "Please enter if Copied to Plex")]

        public bool? CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
