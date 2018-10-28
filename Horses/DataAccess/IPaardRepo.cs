using Horses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horses.DataAccess
{
    public interface IPaardRepo
    {
        IEnumerable<Paard> GetAllPaarden();
        Paard GetPaardById(int id);

    }
}
