﻿using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static Dictionary<int, Person> _persons = new Dictionary<int, Person>();

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person value)
        {
            while (!_persons.TryAdd(value.Id, value))
            {
                value.Id++;
            }

            return Created($"/people/{value.Id}", value);
        }

        [HttpPut("{id:int}/pets")]
        public IActionResult AddPetToPerson(int id, [FromBody] Pet value)
        {
            if (_persons.TryGetValue(id, out var owner))
            {
                owner.Pets.Add(value);

                return Ok(owner);
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpPatch("{id:int}")]
        public IActionResult ChangePerson(int id, [FromBody] Person value)
        {
            if (id != value.Id) return BadRequest();

            if (_persons.TryGetValue(id, out var person))
            {
                _persons[id] = value;

                return Ok(value);
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePerson(int id)
        {
            if (_persons.ContainsKey(id))
            {
                _persons.Remove(id);

                return NoContent();
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

        [HttpPatch("{id:int}/marry/{otherId:int}")]
        public IActionResult MarryPeople(int id, int otherId)
        {
            if (_persons.TryGetValue(id, out var personOne))
            {
                if (_persons.TryGetValue(otherId, out var personTwo))
                {
                    personOne.Marry(personTwo);

                    return Ok(new List<Person> { personOne, personTwo });
                }

                return NotFound($"The person with id {otherId} could not be found.");
            }

            return NotFound($"The person with id {id} could not be found.");
        }

        [HttpDelete("{id:int}/pets/{petName}")]
        public IActionResult RemovePet(int id, string petName)
        {
            if (_persons.TryGetValue(id, out var person))
            {
                if (person.Pets.Exists(p => p.Name.Equals(petName, System.StringComparison.OrdinalIgnoreCase)))
                {
                    person.Pets.RemoveAll(p => p.Name.Equals(petName, System.StringComparison.OrdinalIgnoreCase));

                    return Ok(person);
                }

                return NotFound($"The person with id {id} has no such pet.");
            }

            return NotFound($"The person with id {id} could not be found.");
        }
    }
}