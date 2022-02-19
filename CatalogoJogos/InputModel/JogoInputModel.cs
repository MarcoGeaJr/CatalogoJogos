using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(255, MinimumLength =3, ErrorMessage = "O nome do jogo deve ter entre 3 e 255 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome da produtora deve ter entre 3 e 255 caracteres.")]
        public string Produtora { get; set; }
        [Required]
        [Range(0, 1500, ErrorMessage = "O jogo deve custar entre R$ 0,00 e R$ 1.500,00")]
        public double Preco { get; set; }
    }
}
