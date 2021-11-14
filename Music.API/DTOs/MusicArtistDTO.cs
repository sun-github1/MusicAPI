using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class MusicArtistDTO
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public List<ArtistResultDTO> MusicArtists { get; set; }
    }
}
