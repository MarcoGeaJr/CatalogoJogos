using CatalogoJogos.Exceptions;
using CatalogoJogos.InputModel;
using CatalogoJogos.Services.JogoServices;
using CatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> GetJogos([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 100)]  int quantidade = 25)
        {
            List<JogoViewModel> jogos = await _jogoService.GetJogos(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> GetJogo([FromRoute] Guid idJogo)
        {
            JogoViewModel jogo = await _jogoService.Getjogo(idJogo);

            if (jogo == null)
                return NotFound();

            return Ok(idJogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InsertJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                JogoViewModel jogo = await _jogoService.InsertJogo(jogoInputModel);

                return Ok();
            }
            catch(JaCadastradoException ex)
            {
                return UnprocessableEntity("Registro já cadastrado no banco de dados.");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> UpdateJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.UpdateJogo(idJogo, jogoInputModel);

                return Ok();
            }
            catch(NaoCadastradoException ex)
            {
                return NotFound("Não existe esse registro no banco de dados.");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> UpdateJogo([FromRoute] Guid idJogo, [FromRoute]  double preco)
        {
            try
            {
                await _jogoService.UpdateJogo(idJogo, preco);

                return Ok();
            }
            catch(NaoCadastradoException ex)
            {
                return NotFound("Não existe esse registro no banco de dados.");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeleteJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.DeleteJogo(idJogo);

                return Ok();
            }
            catch(NaoCadastradoException ex)
            {
                return NotFound("Não existe esse registro no banco de dados.");
            }
        }
    }
}
