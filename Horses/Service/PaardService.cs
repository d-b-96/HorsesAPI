using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Horses.DataAccess;
using Horses.Models;
using MySql.Data.MySqlClient;

namespace Horses.Service
{
    public class PaardService : IPaardService
    {
        private PaardContext Context;

        public PaardService(PaardContext paardContext)
        {
            Context = paardContext;
        }
        

        public IEnumerable<Paard> GetAllPaarden()
        {
            //dummytest x
            //return InMemoryPaarden.Paarden;
            IList<Paard> paarden = new List<Paard>();

            using (MySqlConnection conn = Context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from gp_paarden", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paarden.Add(new Paard()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Naam = reader["naam"].ToString(),
                            Type = Convert.ToInt32(reader["type"]),
                            GeboorteDag = DateTime.Now,
                            Geslacht = reader["geslacht"].ToString(),
                            Hoogte = Convert.ToInt32(reader["type"]),
                            Beschrijving = reader["beschrijving"].ToString(),
                            Profielfoto = reader["Profielfoto"].ToString(),
                        });
                    }
                }
            }
            return paarden;
        }

        public Paard GetPaardById(int id)
        {
            //dummytest x
            //return InMemoryPaarden.Paarden.FirstOrDefault(p => p.Id == id);

            Paard paard = new Paard();

            using (MySqlConnection conn = Context.GetConnection())
            {
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from gp_paarden where id = " + id + ";", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paard = new Paard()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Naam = reader["naam"].ToString(),
                            Type = Convert.ToInt32(reader["type"]),
                            GeboorteDag = DateTime.Now,
                            Geslacht = reader["geslacht"].ToString(),
                            Hoogte = Convert.ToInt32(reader["type"]),
                            Beschrijving = reader["beschrijving"].ToString(),
                            Profielfoto = reader["Profielfoto"].ToString(),
                        };
                    }
                }
            }
            return paard;
        }
    }

    /*
    public static class InMemoryPaarden
    {
        public static IEnumerable<Paard> Paarden = new List<Paard>() {
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
        
    }*/
}
