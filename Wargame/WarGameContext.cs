using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Wargame
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public byte[]? Flag { get; set; }
        public List<Tank> Tanks { get; set; } = new();
    }

    public class Tank
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        public int Price { get; set; }
        public int Strenght { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Size { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Optics { get; set; }
        public int Speed { get; set; }
        public int RoadSpeed { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Stealth { get; set; }
        public int Fuel { get; set; }
        public int Range { get; set; }
        public bool IsPrototype { get; set; }
        public bool IsAmphibious { get; set; }
        public int Year { get; set; }
        public int FrontArmor { get; set; }
        public int BackArmor { get; set; }
        public int SideArmor { get; set; }
        public int UpperArmor { get; set; }

        public List<Armament> Armaments { get; set; } = new();
        public List<Type> Types { get; set; } = new();

        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public int MovementId { get; set; }
        public Movement? Movement { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }

    public class Type
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public List<Tank> Tanks { get; set; } = new();
    }

    public class Armament
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Caliber { get; set; }
        public int Range { get; set; }
        public int RangeAircraft { get; set; }
        public int RangeHelicopter { get; set; }
        public int Accuracy { get; set; }
        public int Stability { get; set; }
        public int ArmorPenetration { get; set; }
        public float Landmine { get; set; }
        public int Suppression { get; set; }
        public int RateOfFire { get; set; }
        public List<Property> Properties { get; set; } = new();
        public List<Tank> Tanks { get; set; } = new();
    }

    public class Property
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public List<Armament> Armaments { get; set; } = new();
    }

    public class Movement
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public List<Tank> Tanks { get; set; } = new();
    }

    public class Role
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public List<Tank> Tanks { get; set; } = new();
    }

    public class WarGameContext : DbContext
    {
        public DbSet<Tank> Tanks { get; set; } = null!;
        public DbSet<Country> Countries  { get; set; } = null!;
        public DbSet<Armament> Armaments { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;

        public WarGameContext(DbContextOptions<WarGameContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Country>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Type>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Movement>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Property>().HasAlternateKey(x => x.Name);

            modelBuilder.ApplyConfiguration(new ArmamentConfiguration());
            modelBuilder.ApplyConfiguration(new TankConfiguration());
        }
    }

    public class ArmamentConfiguration : IEntityTypeConfiguration<Armament>
    {
        public void Configure(EntityTypeBuilder<Armament> builder)
        {
            builder.HasAlternateKey(x => x.Name);

            builder.Property(p => p.Caliber).HasDefaultValue("Unknown");

            builder.ToTable(t => t.HasCheckConstraint("Range", "Range >= 0 AND Range <= 3000"));
            builder.ToTable(t => t.HasCheckConstraint("RangeAircraft", "RangeAircraft >= 0 AND RangeAircraft <= 3000"));
            builder.ToTable(t => t.HasCheckConstraint("RangeHelicopter", "RangeHelicopter >= 0 AND RangeHelicopter <= 3000"));
            builder.ToTable(t => t.HasCheckConstraint("Accuracy", "Accuracy >= 0 AND Accuracy <= 100"));
            builder.ToTable(t => t.HasCheckConstraint("Stability", "Stability >= 0 AND Stability <= 100"));
            builder.ToTable(t => t.HasCheckConstraint("ArmorPenetration", "ArmorPenetration >= 0 AND ArmorPenetration <= 30"));
            builder.ToTable(t => t.HasCheckConstraint("Landmine", "Landmine >= 0 AND Landmine <= 10"));
            builder.ToTable(t => t.HasCheckConstraint("Suppression", "Suppression >= 0 AND Suppression <= 400"));
            builder.ToTable(t => t.HasCheckConstraint("RateOfFire", "RateOfFire >= 0 AND RateOfFire <= 3000"));
        }
    }

    public class TankConfiguration : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            builder.HasAlternateKey(x => x.Name);

            builder.Property(p => p.Size).HasDefaultValue("Small");
            builder.Property(p => p.Optics).HasDefaultValue("Bad");
            builder.Property(p => p.Stealth).HasDefaultValue("Bad");

            builder.ToTable(t => t.HasCheckConstraint("Price", "Price >= 0 AND Price <= 200"));
            builder.ToTable(t => t.HasCheckConstraint("Strenght", "Strenght >= 0 AND Strenght <= 10"));
            builder.ToTable(t => t.HasCheckConstraint("Speed", "Speed >= 0 AND Speed <= 120"));
            builder.ToTable(t => t.HasCheckConstraint("RoadSpeed", "RoadSpeed >= 0 AND RoadSpeed <= 150"));
            builder.ToTable(t => t.HasCheckConstraint("Fuel", "Fuel >= 0 AND Fuel <= 2500"));
            builder.ToTable(t => t.HasCheckConstraint("Range", "Range >= 0 AND Range <= 1000"));
            builder.ToTable(t => t.HasCheckConstraint("Year", "Year >= 1940 AND Year <= 2010"));
            builder.ToTable(t => t.HasCheckConstraint("FrontArmor", "FrontArmor >= 0 AND FrontArmor <= 400"));
            builder.ToTable(t => t.HasCheckConstraint("UpperArmor", "UpperArmor >= 0 AND UpperArmor <= 3000"));
            builder.ToTable(t => t.HasCheckConstraint("BackArmor", "BackArmor >= 0 AND BackArmor <= 400"));
            builder.ToTable(t => t.HasCheckConstraint("SideArmor", "SideArmor >= 0 AND SideArmor <= 3000"));

        }
    }
}
