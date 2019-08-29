using System;
using System.Collections.Generic;
using System.Linq;
using HTTPVerbs.Context;
using HTTPVerbs.Model;

namespace HTTPVerbs.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly MySqlContext _context;
        public PersonService(MySqlContext context)
        {
            _context = context;
        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var selectedPerson = _context.Persons
               .SingleOrDefault(x => x.Id.Equals(id));

            if (selectedPerson != null)
            {
                try
                {
                    _context.Persons.Remove(selectedPerson);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<Person> FingAll()
        {
            try
            {
                return _context.Persons.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person Update(Person person)
        {
            var selectedPerson =_context.Persons
                .SingleOrDefault(x => x.Id.Equals(person.Id));

            if(selectedPerson != null)
            {
                try
                {
                    _context.Entry(selectedPerson).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return new Person();
            }

            return person;
        }
    }
}
