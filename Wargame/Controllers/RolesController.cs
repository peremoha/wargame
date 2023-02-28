using Microsoft.AspNetCore.Mvc;

namespace Wargame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly WarGameContext _context;

        public RolesController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetRoles")]
        public IEnumerable<Role> GetRoles() 
        {
            return _context.Roles;
        }

        [HttpGet("GetRoles/{id}")]
        public Role GetRole(int id) 
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id)!;
        }

        [HttpPost("CreateRoles")]
        public int CreateRole(Role role) 
        {
            var response = _context.Roles.Add(role);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("DeleteRoles/{id}")]
        public int DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            var response = _context.Roles.Remove(role!);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("UpdateRoles/{id}")]
        public Role UpdateRole(int id, Role role)
        {
            var oldRole = _context.Roles.FirstOrDefault(r => r.Id == id)!;
            oldRole.Name= role.Name;
            _context.SaveChanges();
            return oldRole;
        }
    }
}
