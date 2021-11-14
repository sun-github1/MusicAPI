using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class MusicAddEditDTO
    {
        public string MusicName { get; set; }
        public int ProducerId { get; set; }
        public List<ArtistIdDTO> ArtistIds { get; set; }
    }
}
