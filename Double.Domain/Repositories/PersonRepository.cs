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
    public class PersonRepository : IPersonRepository
    {
        private readonly DoubleDbContext _context;
        public PersonRepository(DoubleDbContext context)
        {
            _context=context;
        }

        public bool Create(Person person)
        {
            try
            {
                var namesParameter = new SqlParameter("@names", person.Names);
                var lastNamesParameter = new SqlParameter("@lastnames", person.LastNames);
                var numberIdentificationParameter = new SqlParameter("@numberIdentification", person.NumberIdentification);
                var emailParameter = new SqlParameter("@email", person.Email);
                var typeIdentificationParameter = new SqlParameter("@typeIdentification", person.TypeIdentification);
                var numberAndTypeParameter = new SqlParameter("@typeAndNumberIdentification", person.NumberIdentification+"-"+person.TypeIdentification);
                var fullNameParameter = new SqlParameter("@fullname", person.Names+" "+person.LastNames);
                var format = "yyyy-MM-dd HH:mm:ss:fff";
                var stringDate = DateTime.Now.ToString(format);
                var dateParameter = new SqlParameter("@datecreation", stringDate);

                var sqlQuery = @"INSERT INTO [Double].[dbo].[People] (names, lastnames, numberidentification, email, typeidentification,
                                  typeAndNumberIdentification, fullname, datecreation) 
                                 VALUES (@names, @lastnames, @numberIdentification, @email, @typeIdentification, @typeAndNumberIdentification
                                 ,@fullname, @datecreation)";
                
                _context.Database.ExecuteSqlRaw(sqlQuery, namesParameter, lastNamesParameter, numberIdentificationParameter, 
                    emailParameter, typeIdentificationParameter, numberAndTypeParameter, fullNameParameter, dateParameter);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request to create a person went wront!"+ e.Message);
            }
        }

        public Person Get(Guid personId)
        {
            try
            {
                var personIdParameter = new SqlParameter("@personId", personId);
                var sqlQuery = @"SELECT * FROM [Double].[dbo].[People] WHERE personId=@personId";
                var result = _context.People.FromSqlRaw(sqlQuery, personIdParameter).FirstOrDefault();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request to obtain a person went wront!"+ e.Message);
            }
        }

        public List<Person> GetAll()
        {
            try
            {
                var people = _context.People.FromSqlRaw("EXECUTE procedure_all_people").ToList();

                return people;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request to obtain the people went wront!"+ e.Message);
            }
        }
    }
}
