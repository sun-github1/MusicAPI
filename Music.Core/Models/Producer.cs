using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Models
{
    public class Producer
    {
        public Producer()
        {
            Musics = new List<Music>();
        }
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }

        //Navigation Properties
        public ICollection<Music> Musics { get; set; }
    }
}
