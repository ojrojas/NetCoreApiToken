using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RappiApi.Models;

namespace RappiApi.Data
{
    /// <summary>
    /// RappiApiDbContext contexto de base datos,
    /// para la aplicacion test api rappi
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>06/09/2020</date>
    public class RappiApiDbContext : IdentityDbContext<UsuarioAplicacion>
    {
        public RappiApiDbContext() { }
        public RappiApiDbContext(DbContextOptions<RappiApiDbContext> options)
        : base(options) { }

        /// <summary>
        /// DbSet empleados tabla Empleado
        /// </summary>
        /// <value>Empleado</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>

        public DbSet<Empleado> Empleado { get; set; }
        /// <summary>
        /// DbSet areas tabla Empleado
        /// </summary>
        /// <value>Area</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        public DbSet<Area> Area { get; set; }

        /// <summary>
        /// DbSet SubAreas tabla Empleado
        /// </summary>
        /// <value>SubArea</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        public DbSet<SubArea> SubArea { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder builder)
        // {
        //     builder.UseSqlite("Data Source=rappidbcontext.db");
        // }

        /// <summary>
        /// Modelo de base datos creada 
        /// </summary>
        /// <param name="builder">Modelo empleado para el diseño</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}