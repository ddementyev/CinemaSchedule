namespace CinemaSchedule
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CinemaDbModel : DbContext
    {
        public CinemaDbModel()
            : base("name=CinemaDb")
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Theaters> Theaters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .Property(e => e.Movie)
                .IsUnicode(false);

            modelBuilder.Entity<Sessions>()
                .Property(e => e.Theater)
                .IsUnicode(false);

            modelBuilder.Entity<Sessions>()
                .Property(e => e.Movie)
                .IsUnicode(false);

            modelBuilder.Entity<Sessions>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<Theaters>()
                .Property(e => e.Theater)
                .IsUnicode(false);
        }
    }
}
