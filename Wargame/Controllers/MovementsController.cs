using Microsoft.AspNetCore.Mvc;

namespace Wargame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementsController : Controller
    {
        private readonly WarGameContext _context;

        public MovementsController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetMovements")]
        public IEnumerable<Movement> GetMovements() 
        { 
            return _context.Movements; 
        }

        [HttpGet("GetMovements/{id}")]
        public Movement GetMovement(int id)
        {
            return _context.Movements.FirstOrDefault(m => m.Id == id)!;
        }

        [HttpPost("CreateMovements")]
        public int CreateMovement(Movement movement)
        {
            var response = _context.Movements.Add(movement);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("DeleteMovements/{id}")]
        public int DeleteMovement(int id)
        {
            var movement = _context.Movements.FirstOrDefault(m => m.Id == id)!;
            var response = _context.Movements.Remove(movement);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("UpdateMovements/{id}")]
        public Movement UpdateMovement(int id, Movement movement)
        {
            var oldMovement = _context.Movements.FirstOrDefault(m => m.Id == id)!;
            oldMovement.Name = movement.Name;
            _context.SaveChanges();
            return oldMovement;
        }
    }
}
