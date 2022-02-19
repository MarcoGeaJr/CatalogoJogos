using CatalogoJogos.InputModel;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services.JogoServices
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> GetJogos(int pagina, int quantidade);
        Task<JogoViewModel> Getjogo(Guid idJogo);
        Task<JogoViewModel> InsertJogo(JogoInputModel jogo);
        Task UpdateJogo(Guid idJogo, JogoInputModel jogo);
        Task UpdateJogo(Guid idJogo, double preco);
        Task DeleteJogo(Guid idJogo);
    }
}
