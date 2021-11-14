using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class ArtistWithMusicResultDTO
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<MusicDTO> Music { get; set; }
    }
}
