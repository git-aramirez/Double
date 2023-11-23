using Double.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Core.IServices
{
    public interface IUserService
    {
        bool Create(User user);
        bool IsUser(string username, string password);        
    }
}
