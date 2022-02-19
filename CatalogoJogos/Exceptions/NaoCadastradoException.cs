using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Exceptions
{
    public class NaoCadastradoException : Exception
    {
        public NaoCadastradoException()
            : base("Não existe esse registro no banco de dados.")
        { }
    }
}
