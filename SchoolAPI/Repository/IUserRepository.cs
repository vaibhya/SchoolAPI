using SchoolAPI.Model;
using SchoolAPI.ModelDTO;

namespace SchoolAPI.Repository
{
    public interface IUserRepository
    {
        int CreateUser(User user);
        User GetUserById(int id);

    }
}
