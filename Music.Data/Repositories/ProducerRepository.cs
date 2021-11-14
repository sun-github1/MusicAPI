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
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        private MusicDbContext MusicDbContext
        {
            get { return Context as MusicDbContext; }
        }
        public ProducerRepository(MusicDbContext MusicDbContext):base(MusicDbContext)
        {}
        public async Task<IEnumerable<Producer>> GetAllWithProducers()
        {
            return await MusicDbContext.Producers
                .Include(x => x.Musics)
                .ToListAsync();
        }

        public async Task<Producer> GetWithProducerById(int id)
        {
            return await MusicDbContext.Producers
             .Where(x => x.ProducerId == id)
             .Include(x => x.Musics)
             .FirstOrDefaultAsync();
        }

        public async Task<Producer> GetProducerByName(string producerName)
        {
            return await MusicDbContext.Producers
           .Where(x => x.ProducerName == producerName)
           .FirstOrDefaultAsync();
        }
    }
}
