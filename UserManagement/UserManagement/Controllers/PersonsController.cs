using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonRepository personRepository;
        public PersonsController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            personRepository.Insert(person);
            return Ok();
        }

        //[HttpGet]
        //public ActionResult Get()
        //{
        //    IEnumerable<Person> persons = personRepository.Get();
        //    return Ok(persons);
        //}

        [HttpGet]
        public ActionResult Get(string NIK)
        {
            Person persons = personRepository.Get(NIK);
            return Ok(persons);
        }

        [HttpDelete]
        public ActionResult Del(string NIK)
        {
            personRepository.Delete(NIK);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            personRepository.Update(person);
            return Ok();
        }
    }
}
