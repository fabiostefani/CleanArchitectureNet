using System.Linq;
using fabiostefani.io.CleanArch.Repository.database.ef.ModelEf;
using fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings;
using Microsoft.EntityFrameworkCore;

namespace fabiostefani.io.CleanArch.Repository.database.ef
{
    public class CleanArchContext : DbContext
    {
        // public CleanArchContext(DbContextOptions<CleanArchContext> options)
        //     : base(options) 
        // { 

        // }

         public DbSet<ItemEf>? Items { get; set; }
        // public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Port = 5433; Pooling = true; Database = postgres; User Id = postgres; Password = 123456; SearchPath=ccca");
                                      //postgres://postgres:123456@localhost:5433/postgres
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchContext).Assembly);            
        }

        // public async Task<bool> Commit()
        // {
        //     foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //     {
        //         if (entry.State == EntityState.Added)
        //         {
        //             entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //         }

        //         if (entry.State == EntityState.Modified)
        //         {
        //             entry.Property("DataCadastro").IsModified = false;
        //         }
        //     }
            
        //     return await base.SaveChangesAsync() > 0;
        // }
    }
}