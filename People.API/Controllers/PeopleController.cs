using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static Dictionary<int, Person> _people = new Dictionary<int, Person>();

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person value)
        {
            if (!_people.TryAdd(value.Id, value))
            {
                return BadRequest("Could not add a person with the specified id.");
            }

            return Created($"/people/{value.Id}", value);
        }

        [HttpPut("{id}/pets")]
        public IActionResult AddPetToPerson(int id, [FromBody] Pet value)
        {
            Person person = FindPerson(id);
            if (person is null) return NotFound($"The person with id {id} could not be found.");

            person.Pets.Add(value);
            return Ok(person);
        }

        [HttpPatch("{id}")]
        public IActionResult ChangePerson(int id, [FromBody] Person value)
        {
            Person person = FindPerson(id);
            if (person is null) return NotFound($"The person with id {id} could not be found.");

            _people[id] = value;
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (_people.Remove(id))
            {
                return Ok();
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            return Ok(_people.Values);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            Person person = FindPerson(id);
            if (person is null) return NotFound($"The person with id {id} could not be found.");

            return Ok(person);
        }

        [HttpPatch("{id}/marry/{otherId}")]
        public IActionResult MarryPeople(int id, int otherId)
        {
            Person person = FindPerson(id);
            if (person is null) return NotFound($"The person with id {id} could not be found.");
            Person otherPerson = FindPerson(otherId);
            if (otherPerson is null) return NotFound($"The person with id {otherId} could not be found.");

            person.Marry(otherPerson);
            return Ok(new List<Person> { person, otherPerson });
        }

        [HttpDelete("{id}/pets/{petName}")]
        public IActionResult RemovePet(int id, string petName)
        {
            Person person = FindPerson(id);
            if (person is null) return NotFound($"The person with id {id} could not be found.");

            int removedPet = person.Pets.RemoveAll(p => p.Name.Equals(petName, System.StringComparison.OrdinalIgnoreCase));
            if (removedPet == 1) return Ok(person);
            return NotFound($"The person with id {id} has no such pet.");
        }

        private Person FindPerson(int id)
        {
            if (_people.TryGetValue(id, out var person))
            {
                return person;
            }

            return null;
        }
    }
}