using System.Collections.Generic;
using cursoBackendDotNetCore.api.Business.Entities;

namespace cursoBackendDotNetCore.api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();
        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}