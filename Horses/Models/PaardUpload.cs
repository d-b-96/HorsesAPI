using System;

namespace Horses.Models
{
    public class PaardUpload
    {
        public int Id { get; set; }
        public int Volgorde { get; set; }
        public int Type { get; set; }
        public string Afbeelding { get; set; }
        public string Url { get; set; }
        public string Beschrijving { get; set; }
        public string ByWho { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}