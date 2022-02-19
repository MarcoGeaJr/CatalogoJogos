using CatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositories.JogoRepositories
{
    public class JogoRopository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>();

        public Task<List<Jogo>> GetJogos(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }
        public Task<Jogo> GetJogo(Guid idJogo)
        {
            if (!jogos.ContainsKey(idJogo))
                return null;

            return Task.FromResult(jogos[idJogo]);
        }
        public Task<List<Jogo>> GetJogos(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }
        public Task InsertJogo(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }
        public Task UpdateJogo(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }
        public Task DeleteJogo(Guid idJogo)
        {
            jogos.Remove(idJogo);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            // Fechar a conexão com o BD
        }
    }
}
