using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;
using Microsoft.Extensions.Logging;
using ISEN.DotNet.Library.Data;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ISEN.DotNet.Web.Controllers
{
    public class PersonController : BaseController<IPersonRepository, Person>
    {
        public PersonController(
            IPersonRepository personRepository,
            ILogger<PersonController> logger) : base(personRepository, logger)
        {
        }

        public override JsonResult All()
        {
            var persons = Repository.GetAll();

            dynamic result = new ExpandoObject();
            result.now = DateTime.Now;
            result.persons = new List<ExpandoObject>();

            foreach (var person in persons)
            {
                dynamic jsonPerson = new ExpandoObject();
                jsonPerson.id = person.Id;
                jsonPerson.name = $"{person.LastName} {person.FirstName}";
                result.persons.Add(jsonPerson);
            }
            return Json(result);
        }
    }
}
