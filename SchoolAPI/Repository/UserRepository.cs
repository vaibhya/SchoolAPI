using SchoolAPI.Model;
using SchoolAPI.ModelDTO;

namespace SchoolAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDBContext _dbContext;
        public UserRepository(StudentDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public int CreateUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u=> u.Id== id);
            return user;
        }
    }
}
