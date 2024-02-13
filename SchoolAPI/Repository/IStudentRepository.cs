using SchoolAPI.Model;

namespace SchoolAPI.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll(string? firstName, string? lastName, string? email, int? page, int? limit);
        Student GetById(int id);
        int Add(Student student);
        int Update(Student student);
        int Delete(int id);
    }
}
