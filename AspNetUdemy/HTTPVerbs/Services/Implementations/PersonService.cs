using System;
using System.Collections.Generic;
using HTTPVerbs.Model;

namespace HTTPVerbs.Services.Implementations
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //
        }

        public Person FindById(long id)
        {
            return new Person();
        }

        public List<Person> FingAll()
        {
            return new List<Person>();
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
