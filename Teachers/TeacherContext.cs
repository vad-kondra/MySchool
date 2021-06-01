using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Teachers
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions options) : base(options)
        {
        }

        //dotnet ef migrations add InitialCreate
        //dotnet ef database update
        
        public DbSet<Teacher> Teachers { get; set; }
    }
}