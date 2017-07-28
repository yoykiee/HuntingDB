namespace HuntingRegistry.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HuntingDBContext : DbContext
    {
        public HuntingDBContext()
            : base("name=HuntingDBContext")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalsDocument> AnimalsDocuments { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HunterFarm> HunterFarms { get; set; }
        public virtual DbSet<Hunter> Hunters { get; set; }
        public virtual DbSet<HuntType> HuntTypes { get; set; }
        public virtual DbSet<test> tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasMany(e => e.AnimalsDocuments)
                .WithRequired(e => e.Animal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.Summ)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .HasMany(e => e.AnimalsDocuments)
                .WithRequired(e => e.Document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Documents)
                .WithOptional(e => e.DocumentType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Documents)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.SignId);
        }
    }
}
