using cursoBackendDotNetCore.api.Business.Entities;

namespace cursoBackendDotNetCore.api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}