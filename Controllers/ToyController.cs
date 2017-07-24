using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bagAPI.Data;
using bagAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace bagAPI.Controllers
{
    [Route("api/[controller]")]
    //Name of the controller were looking at. 
    public class ToyController : Controller
    {

        private bagAPIContext _context;
        public ToyController(bagAPIContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> toys = from toy in _context.Toy select toy;

            if (toys == null)
            {
                return NotFound();
            }

            return Ok(toys);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Toy.Add(toy);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ToyExists(toy.ToyId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetToy", new { id = toy.ToyId }, toy);
        }

    private bool ToyExists(int toyId)
    {
      return _context.Toy.Count(e => e.ToyId == toyId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
