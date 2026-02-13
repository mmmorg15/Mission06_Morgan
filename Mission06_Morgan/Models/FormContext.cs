using System.Collections.Generic;
using System.Data.Common;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Morgan.Models
{
    // This class represents the database context for the application. It inherits from DbContext and is used to interact with the database. It contains a DbSet property for the movieFormModel, which allows us to perform CRUD operations on the movies table in the database
    public class FormContext : DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) : base(options) //Constructor
        {
        }
        public DbSet<movieFormModel> movies { get; set; }
    }
}
