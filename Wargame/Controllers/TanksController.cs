using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Wargame.Controllers
{
    public class TankModel
    {
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public int Price { get; set; }
        public int Strenght { get; set; }
        public string? Size { get; set; }
        public string? Optics { get; set; }
        public int Speed { get; set; }
        public int RoadSpeed { get; set; }
        public string? Stealth { get; set; }
        public int Fuel { get; set; }
        public int Range { get; set; }
        public bool IsPrototype { get; set; }
        public int Year { get; set; }
        public int FrontArmor { get; set; }
        public int BackArmor { get; set; }
        public int SideArmor { get; set; }
        public int UpperArmor { get; set; }
        public int[]? ArmamentsId { get; set; }
        public int[]? TypesId { get; set; }
        public int CountryId { get; set; }
        public int MovementId { get; set; }
        public int RoleId { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class TanksController : Controller
    {
        private readonly WarGameContext _context;

        public TanksController(WarGameContext context)
        {
            _context = context;
        }

        [HttpGet("GetTanks")]
        public IEnumerable<Tank> GetTanks() 
        {
            return _context.Tanks.Include(t => t.Country).Include(t => t.Movement).Include(t => t.Role).Include(t => t.Armaments).Include(t => t.Types).ToList();
        }

        [HttpGet("GetTanks/{id}")]
        public Tank GetTank(int id)
        {
            return _context.Tanks.FirstOrDefault(t => t.Id == id)!;
        }

        [HttpPost("CreateTanks")]
        public int CreateTank(TankModel tankModel)
        {
            Tank tank = new Tank()
            {
                Name = tankModel.Name,
                Price = tankModel.Price,
                Strenght = tankModel.Strenght,
                Size = tankModel.Size,
                Optics = tankModel.Optics,
                Speed = tankModel.Speed,
                RoadSpeed = tankModel.RoadSpeed,
                Stealth = tankModel.Stealth,
                Fuel = tankModel.Fuel,
                Range = tankModel.Range,
                IsPrototype = tankModel.IsPrototype,
                Year = tankModel.Year,
                FrontArmor = tankModel.FrontArmor,
                BackArmor = tankModel.BackArmor,
                SideArmor = tankModel.SideArmor,
                UpperArmor = tankModel.UpperArmor,
                CountryId = tankModel.CountryId,
                MovementId = tankModel.MovementId,
                RoleId = tankModel.RoleId,
                Image = tankModel.Image
            };
            var armaments = _context.Armaments.Where(a => tankModel.ArmamentsId!.Contains(a.Id));
            var types = _context.Types.Where(t => tankModel.TypesId!.Contains(t.Id));
            //foreach (var armament in armaments)
            //{
            //    tank.Armaments.Add(armament);
            //}
            tank.Armaments.AddRange(armaments);
            //foreach (var type in types)
            //{
            //    tank.Types.Add(type);
            //}
            tank.Types.AddRange(types);
            var response = _context.Tanks.Add(tank);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpDelete("DeleteTanks/{id}")]
        public int DeleteTank(int id)
        {
            var tank = _context.Tanks.FirstOrDefault(t => t.Id == id)!;
            var response = _context.Tanks.Remove(tank);
            _context.SaveChanges();
            return response.Entity.Id;
        }

        [HttpPut("UpdateTanks/{id}")]
        public Tank UpdateTank(int id, Tank tank)
        {
            var oldTank = _context.Tanks.FirstOrDefault(t => t.Id == id)!;

            oldTank.Name = tank.Name;
            oldTank.Image = tank.Image;
            oldTank.Price = tank.Price;
            oldTank.Stealth = tank.Stealth;
            oldTank.Strenght = tank.Strenght;
            oldTank.Optics = tank.Optics;
            oldTank.Size= tank.Size;
            oldTank.Speed = tank.Speed;
            oldTank.RoadSpeed= tank.RoadSpeed;
            oldTank.Fuel = tank.Fuel;
            oldTank.Range= tank.Range;
            oldTank.IsPrototype = tank.IsPrototype;
            oldTank.Year= tank.Year;
            oldTank.FrontArmor = tank.FrontArmor;
            oldTank.BackArmor = tank.BackArmor;
            oldTank.SideArmor = tank.SideArmor;
            oldTank.UpperArmor = tank.UpperArmor;

            oldTank.Country= tank.Country;
            oldTank.Role= tank.Role;
            oldTank.Movement= tank.Movement;

            _context.SaveChanges();
            return oldTank;
        }
    }
}
