using HTTPVerbs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPVerbs.Services
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FingAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
