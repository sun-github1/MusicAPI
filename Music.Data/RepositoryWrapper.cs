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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MusicDbContext _context;
        private ArtistRepository _artistRepository;
        private MusicRepository _musicRepository;
        private ProducerRepository _producerRepository;
        private Artist_MusicRepository _artist_MusicRepository;
        public RepositoryWrapper(MusicDbContext context)
        {
            this._context = context;
        }
        public IArtistRepository Artist => _artistRepository ??= new ArtistRepository(_context);

        public IMusicRepository Music => _musicRepository ??= new MusicRepository(_context);

        public IArtist_MusicRepository Artist_Music => _artist_MusicRepository ?? new Artist_MusicRepository(_context);

        public IProducerRepository Producer {
            get
            {
               return  _producerRepository ??= new ProducerRepository(_context);
            }
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
