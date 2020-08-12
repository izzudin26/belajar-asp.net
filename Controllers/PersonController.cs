using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mongonets.Models;
using mongonets.Services;


namespace mongonets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonServices _personServices;

        public PersonController(PersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet]
        public ActionResult<List<Information>> get() => _personServices.get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Information> Get(string id)
        {
            var person = _personServices.Get(id);
            if(person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        public ActionResult<Information> create(Information person)
        {
          return _personServices.create(person);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, Information Person)
        {
            var person = _personServices.Get(id);
            if(person == null)
            {
                return NotFound();
            }
            _personServices.Update(person.Id, Person);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var person = _personServices.Get(id);
            if(person == null)
            {
                return NotFound();
            }
            _personServices.destroy(person.Id);
            return Ok();
        }
        
    }
}