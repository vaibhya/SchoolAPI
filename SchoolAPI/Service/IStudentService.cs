using SchoolAPI.Model;
using SchoolAPI.ModelDTO;

namespace SchoolAPI.Service
{
    public interface IStudentService
    {
        IEnumerable<StudentResponseDTO> GetAllStudents(string? firstName, string? lastName, string? email, int? page, int? limit);
        StudentUpdateDTO GetStudentById(int id);
        int AddStudent(StudentCreateDTO studentDto);
        int UpdateStudent(StudentUpdateDTO student); 
        int DeleteStudent(int id);

    }
}
