using System.Collections.Generic;

namespace cursoBackendDotNetCore.api.Models
{
    public class ValidaCampoViewModelOutPut
    {
        public IEnumerable<string> Erros {get; private set;}

        public ValidaCampoViewModelOutPut(IEnumerable<string> erros)
        {
            Erros = erros;
        }
        
    }
}