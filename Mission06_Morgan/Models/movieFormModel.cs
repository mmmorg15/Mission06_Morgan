using System.ComponentModel.DataAnnotations;

namespace Mission06_Morgan.Models
{
    // This class represents the model for the movie form in the application. It contains properties that correspond to the fields in the form, such as MovieID, Category, Title, Year, Director, Rating, Edited, LentTo, and Notes. The properties are decorated with data annotations to specify validation rules and requirements for each field
    public class movieFormModel
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Category {  get; set; }

        [Required]
        public string  Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
