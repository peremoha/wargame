using Microsoft.AspNetCore.Mvc;


namespace Wargame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly WarGameContext _context;

        public CountriesController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries;
        }

        [HttpGet("GetCountries/{id}")]
        public Country GetCountry(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id)!;
        }

        [HttpPost("PostCountries")]
        public int CreateCountry(Country country)
        {
            var response = _context.Countries.Add(country);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("DeleteCountries/{id}")]
        public int DeleteCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id)!;
            var response = _context.Countries.Remove(country);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("ChangeCountries/{id}")]
        public Country ChangeCountry(int id, Country country)
        {
            var oldCountry = _context.Countries.FirstOrDefault(country=> country.Id == id)!;
            oldCountry.Name = country.Name;
            oldCountry.Flag = country.Flag;
            _context.SaveChanges();
            return oldCountry;
        }


    }
}
