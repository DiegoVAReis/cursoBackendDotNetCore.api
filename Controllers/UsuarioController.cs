using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cursoBackendDotNetCore.api.Models.Usuarios;
using cursoBackendDotNetCore.api.Models;
using Swashbuckle.AspNetCore.Annotations;
using cursoBackendDotNetCore.api.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using cursoBackendDotNetCore.api.Infraestruture.Data;
using cursoBackendDotNetCore.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using cursoBackendDotNetCore.api.Business.Repositories;
using cursoBackendDotNetCore.api.Configurations;

namespace cursoBackendDotNetCore.api.Controllers
{   

    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {   
        
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authentication;

        public UsuarioController(
            IUsuarioRepository usuarioRepository, 
            IAuthenticationService authentication)
        {
            _usuarioRepository = usuarioRepository;
            _authentication = authentication;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo
        /// </summary>
        /// <param name="loginViewModelInput">View Model do Login</param>
        /// <returns>Retorna Status OK, dados do usuário e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutPut))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            
            var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            // if (usuario.Senha != loginViewModelInput.Senha.GerarSenhaCriptografada())
            // {
            //     return BadRequest("Houve um erro ao tentar acessar");
            // }

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo, 
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };

            var token = _authentication.GerarToken(usuarioViewModelOutput);

            return Ok(new {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        /// <summary>
        /// Este serviço permite cadastrar um usuário não existente
        /// </summary>
        /// <param name="registroViewModelInput">View Model do Registro de Login</param>
        /// <returns>Retorna Status OK, dados do usuário e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar", Type = typeof(RegistroViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutPut))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {

            // var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            // optionsBuilder.UseSqlServer("Server=localhost;Database=dbCurso;user=sa;password=treinamento");

            // CursoDbContext context = new CursoDbContext(optionsBuilder.Options);

            /*
            //Parte que falta fazer - 
            
            --> No package console do Nuget, deve gerar a migration depois de ter instalado o Microsoft.EntityFrameworkCore.Tools

            Comando:
            Add-Migration "Nome"

            Exemplo:
            Add-Migration Base-Initial            
            
            */

            // var pendingMigrations = context.Database.GetPendingMigrations();
            
            // if (pendingMigrations.Count() > 0)
            // {
            //     context.Database.Migrate();    
            // }

            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;
            
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();
            


            return Created("", registroViewModelInput);
        }
    }
}
