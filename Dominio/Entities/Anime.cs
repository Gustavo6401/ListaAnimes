using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Nome Inválido!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Episódio que Parei Inválido")]
        public int EpQueParei { get; set; }
        [Required(ErrorMessage = "Número de Episódios Inválidos")]
        public int NumeroEpisodios { get; set; }
        [Required(ErrorMessage = "Status Inválido")]
        [MaxLength(20)]
        public string? Status { get; set; }
    }
}
