using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Interfaces
{
    /// <summary>
    /// Interfejs wykorzystywany do przechowywania słowników
    /// </summary>
    public interface IDictionary
    {
        /// <summary>
        /// Właściwość, którą użytkownicy mogliby zmieniać przez interfejs aplikacji
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Właściwość ustawiania przez deweloperów, żeby potem móc identyfikować daną wartość słownikową
        /// </summary>
        string Key { get; }
    }
}
