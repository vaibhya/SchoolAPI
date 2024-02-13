using SchoolAPI.Enum;

namespace SchoolAPI.ModelDTO
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNumber { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

    }
    
}
