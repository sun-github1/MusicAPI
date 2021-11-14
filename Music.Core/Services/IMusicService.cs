using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAllMusics();
        Task<Music> GetMusicById(int musicId);
        Task<Music> AddMusic(Music newMusic);
        Task<Music> UpdateMusic(int musicId, Music updatedMusic);
        Task DeleteMusic(Music deleteMusic);
        Task<Music> GetMusicByName(string musicName);
    }
}
