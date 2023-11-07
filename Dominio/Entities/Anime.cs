using Dominio.Entities.Base;

namespace Dominio.Entities
{
    public class Anime : EntityBase
    {
        public string? Nome { get; set; }
        public int NumeroEpisodios { get; set; }
        public string? Status { get; set; }
    }
}
