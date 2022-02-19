using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Exceptions
{
    public class JaCadastradoException : Exception
    {
        public JaCadastradoException()
            : base("Registro já cadastrado no banco de dados.")
        { }
    }
}
