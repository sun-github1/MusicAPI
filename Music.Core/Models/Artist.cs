using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Models
{
    public class Artist
    {
        public Artist()
        {
            Musics = new List<Music>();
        }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        //Navigation Properties
        public ICollection<Music> Musics { get; set; }
    }
}
