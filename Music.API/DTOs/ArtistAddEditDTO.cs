using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.DTOs
{
    public class ArtistAddEditDTO
    {
        [Required]
        public string ArtistName { get; set; }
    }
}
