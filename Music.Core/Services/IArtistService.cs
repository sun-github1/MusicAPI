using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<IEnumerable<Artist>> GetAllArtistWithMusic();
        Task<Artist> GetArtistById(int artistId);
        Task<Artist> AddArtist(Artist newArtist);
        Task<Artist> UpdateArtist(int artistId, Artist updatedArtist);
        Task DeleteArtist(Artist deleteArtist);
        Task<Artist> GetArtistByName(string artistName);
    }
}
