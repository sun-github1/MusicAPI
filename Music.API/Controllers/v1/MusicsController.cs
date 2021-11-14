using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWeb.API.DTOs;
using MusicWeb.Core.Models;
using MusicWeb.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicWeb.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicsController(IMusicService musicService, IMapper mapper)
        {
            this._musicService = musicService;
            this._mapper = mapper;
        }

        // GET: api/<MusicsController>
        [HttpGet("get-all-musics")]
        public async Task<ActionResult<IEnumerable<MusicResultDTO>>> GetAllMusics()
        {
            var allmusics = await _musicService.GetAllMusics();
            var result = _mapper.Map<IEnumerable<MusicResultDTO>>(allmusics);

            return Ok(result);
        }

        // GET api/<MusicsController>/5
        [HttpGet("get-music-by-id/{id}")]
        public async Task<ActionResult<IEnumerable<MusicResultDTO>>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            if (music == null)
            {
                return BadRequest();
            }
            else
            {
                var result = _mapper.Map<MusicResultDTO>(music);
                return Ok(result);
            }
        }

        // POST api/<MusicsController>
        [HttpPost("add-music-with-artist")]
        public async Task<ActionResult<MusicResultDTO>> AddMusic([FromBody] MusicAddEditDTO musicToAdd)
        {
            if (musicToAdd == null)
            {
                return BadRequest();
            }
            var music = _mapper.Map<Music>(musicToAdd);
            var musicwithsamename = await _musicService.GetMusicByName(music.MusicName);

            if (musicwithsamename != null)
            {
                ModelState.AddModelError("MusicName", "Music with same name alreday exists");
                return BadRequest(ModelState);
            }

            var addedmusic = await _musicService.AddMusic(music);
            if (addedmusic == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Music");
            }
            else
            {
                //Add a Location header to the response. The Location header specifies the URI of the newly created employee object
                return CreatedAtAction(nameof(GetMusicById),
                    new { id = addedmusic.MusicId },
                    addedmusic);
            }
        }

        // PUT api/<MusicsController>/5
        [HttpPut("update-music-by-id/{id}")]
        public async Task<ActionResult<MusicResultDTO>> UpdateMusic(int id, 
            [FromBody] MusicAddEditDTO musicToUpdate)
        {
            if (musicToUpdate == null)
            {
                return BadRequest();
            }
            var music = _mapper.Map<Music>(musicToUpdate);

            var existingMusic = await _musicService.GetMusicById(music.MusicId);

            if (existingMusic == null)
            {
                return NotFound($"Music with id {existingMusic.MusicId} not found");
            }

            var updatedMusic = await _musicService.UpdateMusic(id, music);
            if (updatedMusic == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update Music");
            }
            else
            {
                //Add a Location header to the response. The Location header specifies the URI of the newly created employee object
                return CreatedAtAction(nameof(GetMusicById),
                    new { id = updatedMusic.MusicId },
                    updatedMusic);
            }
        }

        // DELETE api/<MusicsController>/5
        [HttpDelete("delete-music-by-id/{id}")]
        public async Task<ActionResult> DeleteMusic(int musicid)
        {
            if (musicid <= 0)
            {
                return BadRequest();
            }

            var existingMusic = await _musicService.GetMusicById(musicid);

            if (existingMusic == null)
            {
                return NotFound($"Music with id {musicid} not found for deletion");
            }

            await _musicService.DeleteMusic(existingMusic);

            return Ok();
        }
    }
}
