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
    //[Route("api/[controller]")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            this._artistService = artistService;
            this._mapper = mapper;
        }

        // GET: api/<ArtistsController>
        [HttpGet("get-artists")]
        public async Task<ActionResult<IEnumerable<ArtistResultDTO>>> GetArtists()
        {
            var allartists = await _artistService.GetAllArtists();
            var result = _mapper.Map<IEnumerable<ArtistResultDTO>>(allartists);

            return Ok(result);
        }

        [HttpGet("get-artists-with-music")]
        public async Task<ActionResult<IEnumerable<ArtistWithMusicResultDTO>>> GetArtistsWithMusic()
        {
            var allartists = await _artistService.GetAllArtistWithMusic();
            var result = _mapper.Map<IEnumerable<ArtistWithMusicResultDTO>>(allartists);

            return Ok(result);
        }

        // GET api/<ArtistsController>/5
        [HttpGet("get-artist-with-music-by-id/{id}")]
        public async Task<ActionResult<ArtistWithMusicResultDTO>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return BadRequest();
            }
            else
            {
                var result = _mapper.Map<ArtistWithMusicResultDTO>(artist);
                return Ok(result);
            }
        }

        // POST api/<ArtistsController>
        [HttpPost("create-artist")]
        public async Task<ActionResult<ArtistResultDTO>> AddArtist([FromBody] ArtistAddEditDTO artisttoadd)
        {
            if (artisttoadd == null)
            {
                return BadRequest();
            }
            var artist = _mapper.Map<Artist>(artisttoadd);
            var artistwithsamename = await _artistService.GetArtistByName(artist.ArtistName);

            if (artistwithsamename != null)
            {
                ModelState.AddModelError("ArtistName", "Artist with same name alreday exists");
                return BadRequest(ModelState);
            }

            var addedartist = await _artistService.AddArtist(artist);
            if (addedartist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Artist");
            }
            else
            {
                //Add a Location header to the response. The Location header specifies the URI of the newly created employee object
                return CreatedAtAction(nameof(GetArtistById),
                    new { id = addedartist.ArtistId },
                    addedartist);
            }
        }

        // PUT api/<ArtistsController>/5
        [HttpPut("update-artist/{id}")]
        public async Task<ActionResult<ArtistResultDTO>> UpdateArtist(int id, [FromBody] ArtistAddEditDTO artistToUpdate)
        {
            if (artistToUpdate == null)
            {
                return BadRequest();
            }
            var artist = _mapper.Map<Artist>(artistToUpdate);

            var existingArtist = await _artistService.GetArtistById(id);

            if (existingArtist == null)
            {
                return NotFound($"Artist with id {id} not found");
            }

            var updatedArtist = await _artistService.UpdateArtist(id, artist);
            if (updatedArtist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update Artist");
            }
            else
            {
                //Add a Location header to the response. The Location header specifies the URI of the newly created employee object
                return CreatedAtAction(nameof(GetArtistById),
                    new { id = updatedArtist.ArtistId },
                    updatedArtist);
            }
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("delete-aritist/{artistid}")]
        public async Task<ActionResult> Delete(int artistid)
        {
            if (artistid <= 0)
            {
                return BadRequest();
            }

            var existingArtist = await _artistService.GetArtistById(artistid);

            if (existingArtist == null)
            {
                return NotFound($"Artist with id {artistid} not found for deletion");
            }

            await _artistService.DeleteArtist(existingArtist);

            return Ok();

        }
    }
}
