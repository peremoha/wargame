using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Wargame.Controllers
{
    public class ArmamentModel
    {
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public string? Caliber { get; set; }
        public int Range { get; set; }
        public int RangeAircraft { get; set; }
        public int RangeHelicopter { get; set; }
        public int Accuracy { get; set; }
        public int Stability { get; set; }
        public int ArmorPenetration { get; set; }
        public int Landmine { get; set; }
        public int Suppression { get; set; }
        public int RateOfFire { get; set; }
        public int[]? PropsId { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class ArmamentsController : Controller
    {
        private readonly WarGameContext _context;

        public ArmamentsController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetArmaments")]
        public IEnumerable<Armament> GetArmaments()
        {
            var arma = _context.Armaments.Include(arm => arm.Properties).ToList();

            foreach(var a in arma)
            {
                Console.WriteLine(a.Name);
                if (a.Properties != null)
                {
                    foreach(var b in a.Properties)
                    {
                        Console.WriteLine(b.Name);
                    }
                }
            }

            return arma;
        }

        [HttpGet("GetArmaments/{id}")]
        public Armament GetArmament(int id)
        {
            return _context.Armaments.FirstOrDefault(a => a.Id == id)!;
        }

        [HttpPost("CreateArmaments")]
        public int CreateArmament(ArmamentModel armamentModel)
        {
            Armament armament = new Armament()
            {
                Name = armamentModel.Name,
                Caliber = armamentModel.Caliber,
                Range = armamentModel.Range,
                RangeAircraft = armamentModel.RangeAircraft,
                RangeHelicopter = armamentModel.RangeHelicopter,
                Accuracy = armamentModel.Accuracy,
                Stability = armamentModel.Stability,
                ArmorPenetration = armamentModel.ArmorPenetration,
                Landmine = armamentModel.Landmine,
                Suppression = armamentModel.Suppression,
                RateOfFire = armamentModel.RateOfFire,
                Image = armamentModel.Image
            };

            var properties = _context.Properties.Where(p => armamentModel.PropsId!.Contains(p.Id));

            foreach (var property in properties)
            {
                armament.Properties.Add(property);
            }

            var response = _context.Armaments.Add(armament);

            _context.SaveChanges();

            return response.Entity.Id;
        }

        [HttpDelete("DeleteArmaments/{id}")]
        public int DeleteArmament(int id)
        {
            var armament = _context.Armaments.FirstOrDefault(a => a.Id == id)!;
            var response = _context.Armaments.Remove(armament);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("UpdateArmaments/{id}")]
        public Armament UpdateArmament(int id, Armament armament)
        {
            var oldArmament = _context.Armaments.FirstOrDefault(a => a.Id == id)!;

            oldArmament.Name = armament.Name;
            oldArmament.Image = armament.Image;
            oldArmament.Caliber = armament.Caliber;
            oldArmament.Range = armament.Range;
            oldArmament.RangeAircraft = armament.RangeAircraft;
            oldArmament.RangeHelicopter = armament.RangeHelicopter;
            oldArmament.Accuracy = armament.Accuracy;
            oldArmament.Stability = armament.Stability;
            oldArmament.ArmorPenetration = armament.ArmorPenetration;
            oldArmament.Landmine = armament.Landmine;
            oldArmament.Suppression = armament.Suppression;
            oldArmament.RateOfFire = armament.RateOfFire;

            _context.SaveChanges();
            return oldArmament;
        }
    }
}
