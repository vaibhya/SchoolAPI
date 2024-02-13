using AutoMapper;
using SchoolAPI.Model;
using SchoolAPI.ModelDTO;
using SchoolAPI.Repository;

namespace SchoolAPI.Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        int IStudentService.AddStudent(StudentCreateDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            return _repository.Add(student);
        }

        int IStudentService.DeleteStudent(int id)
        {
            return _repository.Delete(id);
        }

        IEnumerable<StudentResponseDTO> IStudentService.GetAllStudents( string? firstName, string? lastName, string? email, int? page, int? limit)
        {
            var students = _repository.GetAll(firstName, lastName, email, page, limit);
            var studentResponseDTOs = new List<StudentResponseDTO>();
            foreach(var student in students)
            {
                var studentResponseDTO = _mapper.Map<StudentResponseDTO>(student);
                studentResponseDTO.Age = CalculateAge(student.DateOfBirth);
                studentResponseDTOs.Add(studentResponseDTO);
            }
                
            return studentResponseDTOs;
        }

        StudentUpdateDTO IStudentService.GetStudentById(int id)
        {
            return _mapper.Map<StudentUpdateDTO>(_repository.GetById(id));
        }

        int IStudentService.UpdateStudent(StudentUpdateDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            return _repository.Update(student);
        }

        private static int CalculateAge(DateTime date)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

    }
}
