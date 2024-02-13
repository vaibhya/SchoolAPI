using SchoolAPI.Enum;

namespace SchoolAPI.ModelDTO
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
