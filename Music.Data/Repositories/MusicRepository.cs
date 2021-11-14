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
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private MusicDbContext MusicDbContext
        {
            get
            {
                return Context as MusicDbContext;
            }
        }

        public MusicRepository(MusicDbContext musicDbContext): base(musicDbContext)
        {}

        public async Task<IEnumerable<Music>> GetAllWithArtistss()
        {
            return await MusicDbContext.Musics
                .Include(y=>y.Producer)
                .Include(x => x.Artists)
                .ToListAsync();
        }

        //public async Task<IEnumerable<Music>> GetWithArtistsByMusicId(int musicId)
        //{
        //    return await MusicDbContext.Musics
        //       .Where(x=>x.MusicId==musicId)
        //       .Include(y => y.Producer)
        //       .Include(x => x.Artists)
        //       .ToListAsync();
        //}

        public async Task<Music> GetWithArtistsById(int id)
        {
            var music= await MusicDbContext.Musics
              .Where(x => x.MusicId == id)
              .Include(y => y.Producer)
              //.Include(x => x.Artists)
              .FirstOrDefaultAsync();

            var artistsForMusic = MusicDbContext.Artist_Musics.Where(x => x.MusicId == music.MusicId).Include(s=>s.Artist);
            foreach(var artist in artistsForMusic)
            {
                music.Artists.Add(artist.Artist);
            }
            return music;
            //music.Artists
        }

        public async Task<Music> GetMusicByName(string musicName)
        {
            return await MusicDbContext.Musics
               .Where(x => x.MusicName == musicName)
               .FirstOrDefaultAsync();
        }
    }
}
