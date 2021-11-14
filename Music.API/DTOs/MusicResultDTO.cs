using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class MusicResultDTO
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public ProducerDTO Producer { get; set; }
        public List<ArtistResultDTO> Artists { get; set; }

    }
}
