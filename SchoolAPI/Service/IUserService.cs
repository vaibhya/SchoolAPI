using SchoolAPI.ModelDTO;

namespace SchoolAPI.Service
{
    public interface IUserService
    {
        UserResponseDTO GetUserById(int id);
        int CreateUser(UserCreateDTO user);
    }
}
