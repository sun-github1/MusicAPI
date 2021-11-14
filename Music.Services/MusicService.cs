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
    public class MusicService : IMusicService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public MusicService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }
        
        public async Task<IEnumerable<Music>> GetAllMusics()
        {
            return await _repositoryWrapper.Music.GetAllWithArtistss();
        }

        public async Task<Music> GetMusicById(int musicId)
        {
            var music= await _repositoryWrapper.Music.GetWithArtistsById(musicId);
            
            return music;
        }

        public async Task<Music> GetMusicByName(string musicName)
        {
            return await  _repositoryWrapper.Music.GetMusicByName(musicName);
        }

        public async Task<Music> AddMusic(Music newMusic)
        {
            var result = await _repositoryWrapper.Music.AddAsync(new Music()
            {
                MusicName=newMusic.MusicName,
                ProducerId= newMusic.ProducerId,                
            });
            await _repositoryWrapper.Save();
            if(newMusic.Artists!=null)
            {
                foreach(var eachartist in newMusic.Artists)
                {
                    //var existingARtist = await _repositoryWrapper.Artist.GetById(eachartist.ArtistId);
                    //if (existingARtist != null)
                    //{
                    //    //update
                    //    await _repositoryWrapper.Artist_Music.(
                    //       new Artist_Music()
                    //       {
                    //           ArtistId = eachartist.ArtistId,
                    //           MusicId = result.MusicId
                    //       }
                    //       );
                    //    await _repositoryWrapper.Save();
                    //}
                    //else
                    //{
                        await _repositoryWrapper.Artist_Music.AddAsync(
                            new Artist_Music()
                            {
                                ArtistId = eachartist.ArtistId,
                                MusicId = result.MusicId
                            }
                            );
                        await _repositoryWrapper.Save();
                    //}
                }
            }

            return result;
        }

        public async Task DeleteMusic(Music deleteMusic)
        {
            _repositoryWrapper.Music.Remove(deleteMusic);
            await _repositoryWrapper.Save();
        }

        public async Task<Music> UpdateMusic(int musicId, Music updatedMusic)
        {

            var musicToBeUpdated = await _repositoryWrapper.Music.GetById(musicId);
            musicToBeUpdated.MusicName = updatedMusic.MusicName;
            musicToBeUpdated.ProducerId = updatedMusic.ProducerId;
            musicToBeUpdated.Artists = updatedMusic.Artists;

            await _repositoryWrapper.Save();
            return musicToBeUpdated;
        }

    }
}
