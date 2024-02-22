using Microsoft.EntityFrameworkCore;
using SchoolAPI.Model;

namespace SchoolAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _dbContext;

        public StudentRepository(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int Add(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student.Id;
        }

        int IStudentRepository.Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            if(student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }
        IEnumerable<Student> IStudentRepository.GetAll( string? firstName, string? lastName, string? email, int? page, int? limit)
        {
            IQueryable<Student> students = _dbContext.Students;
            
            
            if(!string.IsNullOrEmpty(firstName))
            {
                students = students.Where(s => s.FirstName.ToLower() == firstName.ToLower());
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                students = students.Where(s => s.LastName.ToLower() == lastName.ToLower());
            }
            if (!string.IsNullOrEmpty(email))
            {
                students = students.Where(s => s.Email.ToLower() == email.ToLower());
            }
            if(page.HasValue && page > 0)
            {
                int pageSize = limit.HasValue ? limit.Value : 10;
                students = students.Skip((page.Value - 1) * pageSize).Take(pageSize);
            }
            if(!page.HasValue && limit > 0)
            {
                students.Take(limit.Value);
            }
            return students.ToList();
        }

        Student IStudentRepository.GetById(int id)
        {
            return _dbContext.Students.FirstOrDefault(s=>s.Id==id);
        }

        int IStudentRepository.Update(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return student.Id;
        }
    }
}
