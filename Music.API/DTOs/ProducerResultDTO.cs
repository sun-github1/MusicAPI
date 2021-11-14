using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class ProducerResultDTO
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public List<MusicArtistDTO> MusicArtists { get; set; }
    }
}
