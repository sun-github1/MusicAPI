using MusicWeb.Core;
using MusicWeb.Core.Repositories;
using MusicWeb.Data.Context;
using MusicWeb.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Data
{
    public class UnitWork : IUnitWork
    {
        private MusicDbContext context;
        private ArtistRepository artistRepository;
        private MusicRepository musicRepository;
        public IArtistRepository ArtistRepository => artistRepository??= new ArtistRepository(context);

        public IMusicRepository MusicRepository => musicRepository??=new MusicRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
