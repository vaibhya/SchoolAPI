using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Model
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions option) : base (option) 
        { 

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
