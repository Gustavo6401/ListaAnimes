using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int NumeroEpisodios { get; set; }
        public string? Status { get; set; }
    }
}
