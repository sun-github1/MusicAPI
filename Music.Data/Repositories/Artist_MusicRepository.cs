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
    public class Artist_MusicRepository : Repository<Artist_Music>, IArtist_MusicRepository
    {
        private MusicDbContext MusicDbContext
        {
            get
            {
                return Context as MusicDbContext;
            }
        }
        public Artist_MusicRepository(MusicDbContext musicDbContext): base(musicDbContext)
        {

        }

    }
}
