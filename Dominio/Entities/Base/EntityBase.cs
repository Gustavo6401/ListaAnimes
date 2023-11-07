using Dominio.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities.Base
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
