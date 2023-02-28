using Microsoft.AspNetCore.Mvc;

namespace Wargame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : Controller
    {
        private readonly WarGameContext _context;

        public PropertiesController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetProperties")]
        public IEnumerable<Property> GetProperties()
        {
            return _context.Properties;
        }

        [HttpGet("GetProperties/{id}")]
        public Property GetProperty(int id) 
        {
            return _context.Properties.FirstOrDefault(p => p.Id == id)!;
        }

        [HttpPost("CreateProperties")]
        public int CreateProperty(Property property) 
        {
            var response = _context.Properties.Add(property);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("DeleteProperties/{id}")]
        public int DeleteProperty(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            var response = _context.Properties.Remove(property!);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("UpdateProperties/{id}")]
        public Property UpdateProperty(int id, Property property)
        {
            var oldProperty = _context.Properties.FirstOrDefault(p => p.Id == id)!;
            oldProperty.Name = property.Name;
            _context.SaveChanges();
            return oldProperty;
        }
    }
}
