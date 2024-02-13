using SchoolAPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAPI.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNumber { get; set;}
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
