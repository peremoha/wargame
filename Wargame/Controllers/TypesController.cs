using Microsoft.AspNetCore.Mvc;

namespace Wargame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : Controller
    {
        private readonly WarGameContext _context;


        public TypesController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetTypes")]
        public IEnumerable<Type> GetAll()
        {
            return _context.Types;
        }

        [HttpGet("GetTypes/{id}")]
        public Type GetOne(int id)
        {
            return _context.Types.FirstOrDefault(t => t.Id == id)!;
        }

        [HttpPost("AddTypes")]
        public int CreateType(Type type)
        {
            var response = _context.Types.Add(type);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("deleteTypes/{id}")]
        public int DeleteType(int id)
        {
            var type = _context.Types.FirstOrDefault(t => t.Id == id)!;
            var response = _context.Types.Remove(type);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("updateTypes/{id}")]
        public Type UpdateType(int id, Type type)
        {
            var oldtype = _context.Types.FirstOrDefault(t => t.Id == id)!;
            oldtype.Name = type.Name;
            _context.SaveChanges();
            return oldtype;
        }

        //[HttpPut("updateTypes")]
        //public Type UpdateSingle(Type type)
        //{
        //    var oldtype = _context.Types.FirstOrDefault(t => t.Id == type.Id)!;
        //    oldtype.Name = type.Name;
        //    _context.SaveChanges();
        //    return oldtype;
        //}

    }
}
