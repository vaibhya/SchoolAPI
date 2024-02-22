using AutoMapper;
using SchoolAPI.Model;
using SchoolAPI.ModelDTO;
using SchoolAPI.Repository;

namespace SchoolAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper,IUserRepository userRepository) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public int CreateUser(UserCreateDTO userDTO)
        {
            var user = _mapper.Map<UserCreateDTO, User>(userDTO);
            return _userRepository.CreateUser(user);    
        }

        public UserResponseDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
