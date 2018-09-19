using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitAndGeese.Model;

namespace RabbitAndGeese.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeeseController : ControllerBase
    {
        List<Goose> Geese;
        public GeeseController()
        {

            /**    static List<Goose>Geese = new List<Goose> */
            //static shares it with all geese controllers after made once
            Geese = new List<Goose> 
            {
                new Goose {Name ="Ben", Sex = Sex.Male, Social = false},
                new Goose {Name ="Mary", Sex = Sex.Female, Social = true},
                new Goose {Name ="Cynthia", Sex = Sex.Female, Social = false}, //Enum.Parse<>
                new Goose {Name ="David", Sex = Sex.Male, Social = true},
                new Goose {Name ="Steve", Sex = Sex.Male, Social = false},
                new Goose {Name ="Adam", Sex = Sex.Male, Social = true},
                new Goose {Name ="Cloe", Sex = Sex.Female, Social = true},
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Goose>> GetAll()
        {
            return Geese;
        }

        [HttpGet("cool")]
        public ActionResult<IEnumerable<Goose>> GetCoolMaleGeese()
        {
            //lamda expression
            //in a Where(add function or function name)
            var coolGeese = Geese.Where(goose => goose.Sex == Sex.Male && goose.Social);
            return Ok(coolGeese);
        }



        [HttpPost]
        public IActionResult AddAGoose(Goose goose)
        {
            Geese.Add(goose);
            return Ok();
        }
    }
}