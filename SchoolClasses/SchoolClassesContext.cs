using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolClasses
{
    public class SchoolClassesContext : DbContext
    {
        public SchoolClassesContext(DbContextOptions options) : base(options)
        {
        }

        
        
    }
}