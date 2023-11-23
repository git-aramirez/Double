using Double.Core.IServices;
using Double.Domain.IRepositories;
using Double.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Create(User user)
        {
            return _userRepository.Create(user);
        }

        public bool IsUser(string username, string password)
        {
            return _userRepository.IsUser(username, password);
        }
    }
}
