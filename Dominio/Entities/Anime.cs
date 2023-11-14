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
        public Anime(int id, string? nome, int epQueParei, int numeroEpisodios, string? status)
        {
            Id = id;
            Nome = nome;
            EpQueParei = epQueParei;
            NumeroEpisodios = numeroEpisodios;
            Status = status;
        }
        public Anime(string? nome, int epQueParei, int numeroEpisodios, string? status)
        {
            Nome = nome;
            EpQueParei = epQueParei;
            NumeroEpisodios = numeroEpisodios;
            Status = status;
        }

        public int Id { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Nome Inválido!")]
        public string? Nome { get; private set; }
        [Required(ErrorMessage = "Episódio que Parei Inválido")]
        public int EpQueParei { get; private set; }
        [Required(ErrorMessage = "Número de Episódios Inválidos")]
        public int NumeroEpisodios { get; private set; }
        [Required(ErrorMessage = "Status Inválido")]
        [MaxLength(20)]
        public string? Status { get; private set; }
    }
}
