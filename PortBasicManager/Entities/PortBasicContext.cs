using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace PortBasicManager.Entities
{
    public partial class PortBasicContext : DbContext    //Bytt namn på databasen för att senare köra en Migration
    {
        string connectionString = string.Empty;
        public virtual DbSet<Port> Ports { get; set; }

        public virtual DbSet<Vessel> Vessels { get; set; }

        public virtual DbSet<RejectedVessel> RejectedVessels { get; set; }



        public PortBasicContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false);
            var app = builder.Build();
            connectionString = app.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public PortBasicContext(DbContextOptions<PortBasicContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_CI_AI");


            modelBuilder.Entity<Port>(entity =>
            {
                entity.HasKey(e => e.SlotId).HasName("PK_Port");  

                entity.ToTable("Ports");

                entity.Property(e => e.SlotId).ValueGeneratedNever();
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Occupancy).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.VesselIdA).HasMaxLength(12);  // Kolumn för första båtens ID
                entity.Property(e => e.VesselIdB).HasMaxLength(12);  // Kolumn för andra båtens ID (vid delad plats)
            });

            modelBuilder.Entity<Vessel>(entity =>
            {
                entity.HasKey(e => e.VesselId).HasName("PK_Vessel");  

                entity.ToTable("Vessels");

                entity.Property(e => e.VesselId)
                    .HasMaxLength(5)
                    .IsFixedLength();
                entity.Property(e => e.VesselType).HasMaxLength(15);
                entity.Property(e => e.WeightInKg).HasColumnType("float");
                entity.Property(e => e.SpeedInKnots).HasColumnType("float");
                entity.Property(e => e.VesselSize).HasColumnType("float");
                entity.Property(e => e.LayTime).HasColumnType("int");

                // TPH-konfiguration för specifika fartyg
                entity.HasDiscriminator<string>("VesselType")
                    .HasValue<CargoShip>("CargoShip")
                    .HasValue<MotorBoat>("Motorboat")
                    .HasValue<RowBoat>("Rowboat")
                    .HasValue<SailBoat>("Sailboat");
            });

            modelBuilder.Entity<RejectedVessel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_RejectedVessel");
                entity.ToTable("RejectedVessels");
                entity.Property(e => e.VesselId).HasMaxLength(12).IsRequired();
            });

            // Seeding of port slots
            for (int i = 1; i <= 64; i++)
            {
                modelBuilder.Entity<Port>().HasData(new Port
                {
                    SlotId = i,
                    Id = i,  
                    Occupancy = 0,  // Start with all slots being free
                    FreeSlots = null
                });
            }
        }
    }
}
