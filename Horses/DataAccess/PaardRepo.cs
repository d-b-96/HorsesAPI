using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Horses.Models;
using MySql.Data.MySqlClient;

namespace Horses.DataAccess
{
    public class PaardRepo : IPaardRepo
    {
        private readonly PaardContext _context;

        private readonly string Query =
            "SELECT " +
            "p.id as p_id, p.naam, p.type as p_type, p.geboorteDag, p.geslacht, p.hoogte, p.beschrijving as p_beschrijving, p.profielfoto, p.media, p.link, p.by_who as p_by_who, p.created_at as p_created_at, p.updated_at as p_updated_at, " +
            "u.id as u_id, u.volgorde, u.type as u_type, u.afbeelding, u.url, u.beschrijving as u_beschrijving, u.by_who as u_by_who, u.updated_at as u_updated_at, u.created_at as u_created_at " +
            "FROM gp_paarden p LEFT JOIN gp_paarden_upload u ON(p.id = u.paard_id)";
       
        public PaardRepo(PaardContext paardContext)
        {
            _context = paardContext;
        }

        public IEnumerable<Paard> GetAllPaarden()
        {
            IList<Paard> paarden = new List<Paard>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["p_id"]);
                        bool exists = false;
                        Paard paard;

                        foreach(var p in paarden)
                        {
                            if (p.Id == id) exists = true;
                        }

                        if (exists)
                        {
                            paard = paarden.FirstOrDefault(p => p.Id == id);
                        }
                        else
                        {
                            paard = new Paard()
                            {
                                Id = id,
                                Naam = reader["naam"].ToString(),
                                Type = Convert.ToInt32(reader["p_type"]),
                                GeboorteDag = DateTime.Now,
                                Geslacht = reader["geslacht"].ToString(),
                                Hoogte = Convert.ToInt32(reader["hoogte"]),
                                Beschrijving = reader["p_beschrijving"].ToString(),
                                Profielfoto = reader["profielfoto"].ToString(),
                                Media = reader["media"].ToString(),
                                Link = reader["link"].ToString(),
                                ByWho = reader["p_by_who"].ToString(),
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                PaardUploads = new List<PaardUpload>()
                            };
                        }

                        int uId = 0;
                        int volgorde = 0;
                        int type = 0;
                        string afbeelding = "";
                        string url = "";
                        string beschrijving = "";
                        string byWho = "";
                        DateTime createdAt = DateTime.Now;
                        DateTime updatedAt = DateTime.Now;

                        if (!(reader["u_id"] is DBNull)) uId = Convert.ToInt32(reader["u_id"]);
                        if (!(reader["volgorde"] is DBNull)) volgorde = Convert.ToInt32(reader["volgorde"]);
                        if (!(reader["u_type"] is DBNull)) type = Convert.ToInt32(reader["u_type"]);
                        if (!(reader["afbeelding"] is DBNull)) afbeelding = reader["afbeelding"].ToString();
                        if (!(reader["url"] is DBNull)) url = reader["url"].ToString();
                        if (!(reader["u_beschrijving"] is DBNull)) beschrijving = reader["u_beschrijving"].ToString();
                        if (!(reader["u_by_who"] is DBNull)) byWho = reader["u_by_who"].ToString();

                        PaardUpload pu = new PaardUpload()
                        {
                            Id = uId,
                            Volgorde = volgorde,
                            Type = type,
                            Afbeelding = afbeelding,
                            Url = url,
                            Beschrijving = beschrijving,
                            ByWho = byWho,
                            CreatedAt = createdAt,
                            UpdatedAt = updatedAt,
                        };

                        /*
                        foreach (var x in paarden.Where(c => c.Id == id))
                        {
                            x.PaardUploads.ToList().Add(pu);
                        }
                        */

                        //paard.PaardUploads.ToList().Add(pu);
                        if (!exists) paarden.Add(paard);
                    }
                }
            }

            return paarden;
        }

        public Paard GetPaardById(int id)
        {
            Paard paard = new Paard();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query + "WHERE p_id = " + id + ";", conn);

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
                            Profielfoto = reader["profielfoto"].ToString(),

                        };
                    }
                }
            }

            return paard;
        }
    }
}
