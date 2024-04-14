using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> _visits = new List<Visit>()
    {
        new Visit(DateTime.Parse("2024-03-12"), AnimalsController._animals[0],"Treatment",1234.23),
        new Visit(DateTime.Parse("2024-03-28"), AnimalsController._animals[1],"Survey",100),
        new Visit(DateTime.Parse("2024-04-07"), AnimalsController._animals[0],"Treatment",500),

    };

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalVisits(int id)
    {
        var animal = AnimalsController._animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null)
        {
            return NotFound("There no animal with such id");
        }

        var result = _visits.Where(v => v.Animal.Equals(animal)).ToList();
        if (result.Count==0)
        {
            return NotFound("This animal doesn`t have a visits");
        }
        return Ok(result);
    }
    [HttpPost]
    public IActionResult AddNewAnimalVisit(Visit visit)
    {
        if (AnimalsController._animals.Any(a => a.IdAnimal == visit.Animal.IdAnimal))
        {
            return NotFound("This animal already in database");
        }
        new AnimalsController().AddAnimal(visit.Animal);
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("{id:int}")]
    public IActionResult AddOldAnimalVisit(DateTime date, int id,string description, double price)
    {
        var animal = AnimalsController._animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal==null)
        {
            return NotFound("This animal ain`t in database");
        }

        _visits.Add(new Visit(date, animal,description,price));
        return StatusCode(StatusCodes.Status201Created);
    }
}