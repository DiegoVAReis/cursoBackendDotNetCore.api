using cursoBackendDotNetCore.api.Models.Usuarios;

namespace cursoBackendDotNetCore.api.Configurations
{
    public interface IAuthenticationService
    {
         string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}