using Double.Domain.IRepositories;
using Double.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DoubleDbContext _context;
        public UserRepository(DoubleDbContext context)
        {
            _context=context;
        }

        public bool Create(User user)
        {
            try
            {
                var format = "yyyy-MM-dd HH:mm:ss:fff";
                var stringDate = DateTime.Now.ToString(format);
                var usernameParameter = new SqlParameter("@username", user.Username);
                var passwordParameter = new SqlParameter("@password", user.Password);
                var dateParameter = new SqlParameter("@datecreation", stringDate);
                var sqlQuery = @"INSERT INTO [Double].[dbo].[User] (username, password, datecreation) 
                                 VALUES (@username, @password, @datecreation)";
                _context.Database.ExecuteSqlRaw(sqlQuery, usernameParameter, passwordParameter, dateParameter);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request to create a user went wront!"+ e.Message);
            }
        }

        public bool IsUser(string username, string password)
        {
            try
            {
                var usernameParameter = new SqlParameter("@username", username);
                var passwordParameter = new SqlParameter("@password", password);
                var sqlQuery = @"SELECT * FROM [Double].[dbo].[User] WHERE username=@username AND password=@password";
                var result = _context.Users.FromSqlRaw(sqlQuery, usernameParameter, passwordParameter).FirstOrDefault();

                return result!=null;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request to validate a user went wront!"+ e.Message);
            }
        }
    }
}
