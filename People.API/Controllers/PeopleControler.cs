using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleControler : ControllerBase
    {
        private Dictionary<int, Person> _persons;

        public PeopleControler()
        {
            _persons = new Dictionary<int, Person>();
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] string value)
        {
            Person input;

            try
            {
                input = JsonSerializer.Deserialize<Person>(value);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            int id = 1;
            while (!_persons.TryAdd(id, input))
            {
                id++;
            }

            return Created($"/people/{id}", input);
        }

        [HttpPut("{id:int}")]
        public IActionResult ChangePerson(int id, [FromBody] string value)
        {
            if (_persons.TryGetValue(id, out var person))
            {
                Person updatedPerson;
                try
                {
                    updatedPerson = JsonSerializer.Deserialize<Person>(value);
                }
                catch (ArgumentException)
                {
                    return BadRequest();
                }

                _persons.Remove(id);
                _persons.Add(id, updatedPerson);

                return Ok(updatedPerson);
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePerson(int id)
        {
            if (_persons.TryGetValue(id, out var person))
            {
                _persons.Remove(id);

                return NoContent();
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpDelete("{id:int}/pets/{name}")]
        public IActionResult RemovePet(int id, string petName)
        {
            if (_persons.TryGetValue(id, out var person))
            {
                if (person.Pets.Exists(p => p.Name == petName))
                {
                    person.Pets.RemoveAll(p => p.Name == petName);

                    return NoContent();
                }

                return NotFound($"The person with id {id} has no such pet.");
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPerson(int id)
        {
            if (_persons.TryGetValue(id, out var person))
            {
                return Ok(person);
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_persons.Values);
        }

        [HttpPatch("{id:int}/pets")]
        public IActionResult AddPetToPerson(int id, [FromBody] string value)
        {
            if (_persons.TryGetValue(id, out var owner))
            {
                Pet pet;

                try
                {
                    pet = JsonSerializer.Deserialize<Pet>(value);
                }
                catch (ArgumentException)
                {
                    return BadRequest();
                }

                owner.Pets.Add(pet);

                return Ok(owner);
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpPost("{id:int}/marry/{id:int}")]
        public IActionResult MarryPeople(int id, int otherId)
        {
            if (_persons.TryGetValue(id, out var personOne))
            {
                if (_persons.TryGetValue(otherId, out var personTwo))
                {
                    personOne.Marry(personTwo);

                    return NoContent();
                }

                return NotFound($"The person with id {id} could not be found.");
            }

            return NotFound($"The person with id {id} could not be found.");
        }
    }
}