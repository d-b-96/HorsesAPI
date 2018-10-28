using Horses.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horses.Models
{
    public class Paard
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Type { get; set; }
        public DateTime GeboorteDag { get; set; }
        public string Geslacht { get; set; }
        public int Hoogte { get; set; }
        public string Beschrijving { get; set; }
        public string Profielfoto { get; set; }
        public string Media { get; set; }
        public string Link { get; set; }
        public string ByWho { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<PaardUpload> PaardUploads { get; set; }

    }
}
