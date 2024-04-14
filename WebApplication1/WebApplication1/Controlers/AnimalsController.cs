using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    public static readonly List<Animal> _animals = new List<Animal>()
    {
        new Animal ( 1,  "Thomas",  "Cat",  "White", 3.23 ),
        new Animal ( 2,  "Ball",  "Dog",  "Brown", 37.45 ),
        new Animal ( 3,  "Splinter",  "Rat",  "Black", 0.45 )

    };
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(s=> s.IdAnimal==id);
        if (animal == null)
        {
            return NotFound("There no one with this id");
        }

        return Ok(animal);
    }
    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(s => s.IdAnimal == id);

        if (animalToEdit == null)
        {
            return NotFound("There no one with this id");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(s => s.IdAnimal == id);
        if (animalToDelete == null)
        {
            return NotFound("There is no such student");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}