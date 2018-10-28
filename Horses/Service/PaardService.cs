using System.Collections.Generic;
using Horses.DataAccess;
using Horses.Models;

namespace Horses.Service
{
    public class PaardService : IPaardService
    {
        private readonly IPaardRepo _paardRepo;

        public PaardService(IPaardRepo paardRepo)
        {
            _paardRepo = paardRepo;
        }

        public IEnumerable<Paard> GetAllPaarden()
        {
            return _paardRepo.GetAllPaarden();
        }

        public Paard GetPaardById(int id)
        {
            return _paardRepo.GetPaardById(id);
        }
    }
}
