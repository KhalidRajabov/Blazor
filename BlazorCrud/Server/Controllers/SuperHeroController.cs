
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic>
        {
            new Comic {Id =1, Name="Marvel"},
            new Comic {Id =2, Name="DC"}
        };
        public static List<Superhero> heroes= new List<Superhero>
        {
            new Superhero
            {
                Id =1,
                FirstName="Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                Comic = comics[0]
            },
            new Superhero
            {
                Id =2,
                FirstName="Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                Comic = comics[1]
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetOneSuperhero(int? id)
        {
            if (id == null) return NotFound("Id is wrong");
            Superhero hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null) return NotFound("Hero not found");
            return Ok(hero);
        }
    }
}
