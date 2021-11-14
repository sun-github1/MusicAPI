using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Models
{
    public class Artist_Music
    {
        public int Id { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }


        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
