using CatalogoJogos.InputModel;
using CatalogoJogos.Repositories.JogoRepositories;
using CatalogoJogos.ViewModel;
using CatalogoJogos.Exceptions;
using CatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services.JogoServices
{
    public class JogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> GetJogos(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.GetJogos(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }
        public async Task<JogoViewModel> GetJogo(Guid idJogo)
        {
            var jogo = await _jogoRepository.GetJogo(idJogo);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<JogoViewModel> InsertJogo(JogoInputModel jogoInputModel)
        {
            var entidadeJogo = await _jogoRepository.GetJogos(jogoInputModel.Nome, jogoInputModel.Produtora);

            if (entidadeJogo.Count() > 0)
                throw new JaCadastradoException();


            var jogo = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogoInputModel.Nome,
                Produtora = jogoInputModel.Produtora,
                Preco = jogoInputModel.Preco
            };

            await _jogoRepository.InsertJogo(jogo);

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task UpdateJogo(Guid idJogo, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.GetJogo(idJogo);

            if (entidadeJogo == null)
                throw new NaoCadastradoException();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.UpdateJogo(entidadeJogo);
        }

        public async Task UpdateJogo(Guid idJogo, double preco)
        {
            var entidadeJogo = await _jogoRepository.GetJogo(idJogo);

            if (entidadeJogo == null)
                throw new NaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.UpdateJogo(entidadeJogo);
        }

        public async Task DeleteJogo(Guid idJogo)
        {
            var entidadeJogo = await _jogoRepository.GetJogo(idJogo);

            if (entidadeJogo == null)
                throw new NaoCadastradoException();

            await _jogoRepository.DeleteJogo(idJogo);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
