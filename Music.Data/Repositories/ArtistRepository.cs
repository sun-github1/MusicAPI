using Microsoft.EntityFrameworkCore;
using MusicWeb.Core.Models;
using MusicWeb.Core.Repositories;
using MusicWeb.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private MusicDbContext MusicDbContext
        {
            get
            {
                return Context as MusicDbContext;
            }
        }

        public ArtistRepository(MusicDbContext musicDbContext):base(musicDbContext)
        { }
        public async Task<IEnumerable<Artist>> GetAllWithMusics()
        {
            return await MusicDbContext.Artists
                .Include(x => x.Musics)
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetWithMusicsByArtistId(int artistId)
        {
            return await MusicDbContext.Artists
                .Where(y=>y.ArtistId==artistId)
                .Include(x => x.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsById(int id)
        {
            return await MusicDbContext.Artists
                .Where(y => y.ArtistId == id)
                .Include(x => x.Musics)
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> GetArtistByName(string artistName)
        {
            return await MusicDbContext.Artists
               .Where(y => y.ArtistName == artistName)
               .FirstOrDefaultAsync();
        }


    }
}
