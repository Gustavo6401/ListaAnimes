using Dominio.DTOs;
using Dominio.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnitario.Mock.RepositoryMock
{
    public class AnimeRepositoryMock : IAnimeRepository
    {
        // Escrevi essa classe apenas para conseguir inicializar a classe de teste corretamente.
        List<Anime> lista;

        public AnimeRepositoryMock()
        {
            lista = new List<Anime>
            {
                new Anime(1, "Naruto Shippuden", 80, 500, "Assistindo"),
                new Anime(2, "Dragon Ball Z", 82, 291, "Assistindo"),
                new Anime(3, "One Piece", 44, 1081, "Assistindo")
            };
        }

        public async Task Create(Anime entity)
        {
            lista.Add(entity);
        }

        public async Task Delete(int id)
        {
            Anime anime = lista.FirstOrDefault(a => a.Id == id);

            lista.Remove(anime);
        }

        public async Task<IList<Anime>> GetAll()
        {
            return lista;
        }

        public async Task<Anime> GetById(int id)
        {
            return lista.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Anime> GetByName(string nome)
        {
            return lista.FirstOrDefault(a => a.Nome == nome);
        }

        public async Task Update(Anime entity)
        {
            // O ID nesse caso, representa a posição do elemento. O que estou fazendo é modificar manualmente esse dado. 
            lista[entity.Id - 1] = entity;
        }
    }
}
