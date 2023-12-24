using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class AnimeDTO
    {
        public AnimeDTO()
        {

        }
        public AnimeDTO(int id, string? nome, int numeroEpisodios, string? status, int epQueParei)
        {
            Id = id;
            Nome = nome;
            NumeroEpisodios = numeroEpisodios;
            Status = status;
            EpQueParei = epQueParei;
            PorcentagemConcluida = (decimal)EpQueParei * 100 / NumeroEpisodios;
        }

        public AnimeDTO(string? nome, int numeroEpisodios, string? status, int epQueParei)
        {
            Nome = nome;
            NumeroEpisodios = numeroEpisodios;
            Status = status;
            EpQueParei = epQueParei;
            PorcentagemConcluida = (decimal)EpQueParei * 100 / NumeroEpisodios;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Nome Obrigatório!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Número de Episódios Inválido")]
        public int NumeroEpisodios { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Status Obrigatório!")]
        public string? Status { get; set; }
        public int EpQueParei { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal PorcentagemConcluida { get; set; }

        // Tentei dessa forma, mas não funcionou.
        // public decimal PorcentagemConclusao() => this.PorcentagemConcluida = EpQueParei * 100 / NumeroEpisodios;
    }
}
