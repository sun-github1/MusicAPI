using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusics();
        Task<Artist> GetWithMusicsById(int id);
        Task<IEnumerable<Artist>> GetWithMusicsByArtistId(int artistId);
        Task<Artist> GetArtistByName(string artistName);
    }
}
