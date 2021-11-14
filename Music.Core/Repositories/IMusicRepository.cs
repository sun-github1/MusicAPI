using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWithArtistss();
        Task<Music> GetWithArtistsById(int id);
        Task<Music> GetMusicByName(string musicName);
        //Task<IEnumerable<Music>> GetWithArtistsByMusicId(int musicId);
    }
}
