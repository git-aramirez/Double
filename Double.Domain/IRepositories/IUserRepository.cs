using Double.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Domain.IRepositories
{
    public interface IUserRepository
    {
        bool Create(User user);
        bool IsUser(string username, string password);
    }
}
