using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class AnimeDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Nome Obrigatório!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Número de Episódios Inválido")]
        public int NumeroEpisodios { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Status Obrigatório!")]
        public string? Status { get; set; }
    }
}
