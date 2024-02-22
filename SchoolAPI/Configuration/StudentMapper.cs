using AutoMapper;
using SchoolAPI.Model;
using SchoolAPI.ModelDTO;
using SchoolAPI.Service;

namespace SchoolAPI.Configuration
{
    public class StudentMapper : Profile
    {
        public StudentMapper() 
        {
            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<Student,StudentUpdateDTO>();
            CreateMap<Student, StudentResponseDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserResponseDTO>();
                
        }
    }
}
