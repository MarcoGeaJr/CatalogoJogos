using CatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> GetJogos(int pagina, int quantidade);
        Task<Jogo> GetJogo(Guid idJogo);
        Task<List<Jogo>> GetJogos(string nome, string produtora);
        Task<Jogo> InsertJogo(Jogo jogo);
        Task UpdateJogo(Jogo jogo);
        Task DeleteJogo(Guid idJogo);
    }
}
