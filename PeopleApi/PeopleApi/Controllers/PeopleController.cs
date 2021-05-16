using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        private static List<Person> _people = new List<Person>();

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _people.Add(person);

            return Created("/person", person);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person newPerson)
        {
            var oldPerson = FindPerson(id);

            if (oldPerson == null)
            {
                return NotFound($"Person by id {id} not found.");
            }

            oldPerson.Id = newPerson.Id;
            oldPerson.Name = newPerson.Name;
            oldPerson.Age = newPerson.Age;
            oldPerson.Pets = newPerson.Pets;
            oldPerson.SpouseId = newPerson.SpouseId;

            return Ok(oldPerson);


        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_people);
        }

        [HttpPatch("{id}")]
        public IActionResult AddPet(int id, Pet pet)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id {id} not found.");
            }

            person.Pets.Add(pet);

            return Ok();
        }

        [HttpPatch("marry/{personId}/{otherPersonId}")]
        public IActionResult Marry(int personId, int otherPersonId)
        {
            var person = FindPerson(personId);
            var otherPerson = FindPerson(otherPersonId);

            if (person == null)
            {
                return NotFound($"Person by id {personId} not found.");
            }

            if (otherPerson == null)
            {
                return NotFound($"Person by id {otherPersonId} not found.");
            }

            person.Marry(otherPerson);

            return Ok(person);

        }

        [HttpDelete("{id}")]
        public IActionResult RemovePerson(int id)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id {id} not found.");
            }

            _people.Remove(person);

            return Ok();
        }

        [HttpDelete("{personId}/pets/{petName}")]
        public IActionResult RemovePet(int personId, string petName)
        {
            var person = FindPerson(personId);

            if (person == null)
            {
                return NotFound($"Person by id {personId} not found.");
            }

            var pet = FindPet(person, petName);

            if (pet == null)
            {
                return NotFound($"Pet by name {petName} not found.");
            }

            person.Pets.Remove(pet);

            return Ok();
        }

        private Person FindPerson(int id)
        {
            foreach (var person in _people)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        private Pet FindPet(Person person, string petName)
        {
            foreach (var pet in person.Pets)
            {
                if (pet.Name == petName)
                {
                    return pet;
                }
            }

            return null;
        }




    }
}
