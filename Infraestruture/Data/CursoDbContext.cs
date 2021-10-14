using Microsoft.EntityFrameworkCore;
using cursoBackendDotNetCore.api.Infraestruture.Data.Mappings;
using cursoBackendDotNetCore.api.Business.Entities;

namespace cursoBackendDotNetCore.api.Infraestruture.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
    
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario{get; set;} 
        public DbSet<Curso> Curso{get; set;} 
        
    }
}