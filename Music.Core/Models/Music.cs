using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Models
{
    public class Music
    {
        public Music()
        {
            Artists = new List<Artist>();
        }
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public int ProducerId { get; set; }
        //Navigation Properties
        public Producer Producer { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
