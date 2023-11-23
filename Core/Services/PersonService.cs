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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public bool Create(Person person)
        {
           return _personRepository.Create(person);
        }

        public Person Get(Guid personrId)
        {
           return _personRepository.Get(personrId);
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
    }
}
