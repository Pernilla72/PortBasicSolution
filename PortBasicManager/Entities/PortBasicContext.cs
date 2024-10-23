using Microsoft.EntityFrameworkCore;


namespace PortBasicManager.Entities
{
    public partial class PortBasicContext : DbContext    //Bytt namn på databasen för att senare köra en Migration
    {
        public PortBasicContext(DbContextOptions<PortBasicContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Port> Ports { get; set; }

        public virtual DbSet<Vessel> Vessels { get; set; }

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
                entity.Property(e => e.VesselId).HasMaxLength(12);
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

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
