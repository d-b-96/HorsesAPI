using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Horses.Models;

namespace Horses.DataAccess
{
    public class InMemoryPaardRepo : IPaardRepo
    {
        private IEnumerable<Paard> Paarden = new List<Paard> {
            new Paard() {
                Id = 1,
                Naam = "Matijs",
                Type = 1,
                GeboorteDag = DateTime.Now,
                Geslacht = "M",
                Hoogte = 10,
                Beschrijving = "Fucking kutpaard gast",
                Profielfoto = "url",
            },

            new Paard() {
                Id = 2,
                Naam = "Glenn",
                Type = 2,
                GeboorteDag = DateTime.Now,
                Geslacht = "M",
                Hoogte = 7,
                Beschrijving = "Yala racepaard dreiri",
                Profielfoto = "url",
            },

            new Paard() {
                Id = 3,
                Naam = "Paardenworst",
                Type = 1,
                GeboorteDag = DateTime.Now,
                Geslacht = "M",
                Hoogte = 10,
                Beschrijving = "Mjammie",
                Profielfoto = "url",
            },
        };

        public IEnumerable<Paard> GetAllPaarden()
        {
            return Paarden;
        }

        public Paard GetPaardById(int id)
        {
            return Paarden.FirstOrDefault(p => p.Id == id);
        }
    }
}
