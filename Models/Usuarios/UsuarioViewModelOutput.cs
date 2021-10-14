using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cursoBackendDotNetCore.api.Models.Usuarios
{
    public class UsuarioViewModelOutput
    {
        public int Codigo { get; set; } 
        public string Login { get; set; }  

        public string Email { get; set; }     
    }
}