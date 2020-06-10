using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RappiApi.Models;

namespace RappiApi.Data
{
    public class RappiApiDbContext : IdentityDbContext<UsuarioAplicacion>
    {
         public RappiApiDbContext(){}
        public RappiApiDbContext(DbContextOptions<RappiApiDbContext> options)
        :base(options){}

        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<SubArea> SubArea { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder builder)
        // {
        //     builder.UseSqlite("Data Source=rappidbcontext.db");
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}