using System.Collections.Generic;
using System.Linq;
using cursoBackendDotNetCore.api.Business.Entities;
using cursoBackendDotNetCore.api.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cursoBackendDotNetCore.api.Infraestruture.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {   
        private readonly CursoDbContext _context;

        public CursoRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _context.Curso.Include(i => i.Usuario).Where(w => w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}