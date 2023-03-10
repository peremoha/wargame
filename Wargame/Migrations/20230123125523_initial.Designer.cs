// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wargame;

#nullable disable

namespace Wargame.Migrations
{
    [DbContext(typeof(WarGameContext))]
    [Migration("20230123125523_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArmamentProperty", b =>
                {
                    b.Property<int>("ArmamentsId")
                        .HasColumnType("int");

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.HasKey("ArmamentsId", "PropertiesId");

                    b.HasIndex("PropertiesId");

                    b.ToTable("ArmamentProperty");
                });

            modelBuilder.Entity("ArmamentTank", b =>
                {
                    b.Property<int>("ArmamentsId")
                        .HasColumnType("int");

                    b.Property<int>("TanksId")
                        .HasColumnType("int");

                    b.HasKey("ArmamentsId", "TanksId");

                    b.HasIndex("TanksId");

                    b.ToTable("ArmamentTank");
                });

            modelBuilder.Entity("TankType", b =>
                {
                    b.Property<int>("TanksId")
                        .HasColumnType("int");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("TanksId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("TankType");
                });

            modelBuilder.Entity("Wargame.Armament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("ArmorPenetration")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Landmine")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int>("RangeAircraft")
                        .HasColumnType("int");

                    b.Property<int>("RangeHelicopter")
                        .HasColumnType("int");

                    b.Property<int>("RateOfFire")
                        .HasColumnType("int");

                    b.Property<int>("Stability")
                        .HasColumnType("int");

                    b.Property<int>("Suppression")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Armaments");
                });

            modelBuilder.Entity("Wargame.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Flag")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Wargame.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Wargame.Tank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BackArmor")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("FrontArmor")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsAmphibious")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Optics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Range")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoadSpeed")
                        .HasColumnType("int");

                    b.Property<int>("SideArmor")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Stealth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int>("UpperArmor")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Tanks");
                });

            modelBuilder.Entity("Wargame.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ArmamentProperty", b =>
                {
                    b.HasOne("Wargame.Armament", null)
                        .WithMany()
                        .HasForeignKey("ArmamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wargame.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArmamentTank", b =>
                {
                    b.HasOne("Wargame.Armament", null)
                        .WithMany()
                        .HasForeignKey("ArmamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wargame.Tank", null)
                        .WithMany()
                        .HasForeignKey("TanksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TankType", b =>
                {
                    b.HasOne("Wargame.Tank", null)
                        .WithMany()
                        .HasForeignKey("TanksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wargame.Type", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wargame.Tank", b =>
                {
                    b.HasOne("Wargame.Country", "Country")
                        .WithMany("Tanks")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Wargame.Country", b =>
                {
                    b.Navigation("Tanks");
                });
#pragma warning restore 612, 618
        }
    }
}
