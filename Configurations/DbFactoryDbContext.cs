using Microsoft.EntityFrameworkCore.Design;
using cursoBackendDotNetCore.api.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;

namespace cursoBackendDotNetCore.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=dbCurso;user=sa;password=treinamento");

            CursoDbContext context = new CursoDbContext(optionsBuilder.Options);

            return context;
        }
    }
}