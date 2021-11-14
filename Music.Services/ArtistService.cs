using MusicWeb.Core;
using MusicWeb.Core.Models;
using MusicWeb.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ArtistService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistWithMusic()
        {
            return await _repositoryWrapper.Artist.GetAllWithMusics();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
           return await _repositoryWrapper.Artist.GetAll();
        }

        public async Task<Artist> GetArtistById(int artistId)
        {
            return await _repositoryWrapper.Artist.GetWithMusicsById(artistId);
        }

        public async Task<Artist> GetArtistByName(string artistName)
        {
            return await _repositoryWrapper.Artist.GetArtistByName(artistName);
        }

        public async Task<Artist> AddArtist(Artist newArtist)
        {
            var result = await _repositoryWrapper.Artist.AddAsync(newArtist);
            await _repositoryWrapper.Save();
            return result;
        }

        public async Task DeleteArtist(Artist deletArtist)
        {
            _repositoryWrapper.Artist.Remove(deletArtist);
            await _repositoryWrapper.Save();
        }

        public async Task<Artist> UpdateArtist(int artistId,Artist updatedArtist)
        {
            var artistToBeUpdated = await _repositoryWrapper.Artist.GetById(artistId);
            artistToBeUpdated.ArtistName = updatedArtist.ArtistName;
            //artistToBeUpdated.Mus = updatedArtist.ArtistName;
            await _repositoryWrapper.Save();
            return artistToBeUpdated;
        }

       
    }
}
