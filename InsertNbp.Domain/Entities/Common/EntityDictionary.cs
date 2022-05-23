using InsertNbp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Entities.Common
{
    /// <summary>
    /// Klasa abstrakcyjna dla klas bazodanowych, które są słownikami
    /// </summary>
    public abstract class EntityDictionary : Entity, IDictionary
    {
        public string Name { get; set; }
        public string Key { get; }
    }
}
