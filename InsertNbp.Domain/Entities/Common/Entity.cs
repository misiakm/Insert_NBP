using InsertNbp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Entities.Common
{
    /// <summary>
    /// Klasa abstrakcyjna wykorzystywana do każdej klasy bazodanowej
    /// </summary>
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
    }
}
