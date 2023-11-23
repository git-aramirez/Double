using Double.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Domain.IRepositories
{
    public interface IPersonRepository
    {
        bool Create(Person person);
        Person Get(Guid personrId);
        List<Person> GetAll();
    }
}
