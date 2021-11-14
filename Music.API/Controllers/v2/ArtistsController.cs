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

namespace MusicWeb.API.Controllers.v2
{

    [ApiVersion("2.0")]
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
        public async Task<ActionResult<IEnumerable<ArtistResultDTO>>> GetArtistsV2()
        {
            var allartists = await _artistService.GetAllArtists();
            var result = _mapper.Map<IEnumerable<ArtistResultDTO>>(allartists);

            return Ok(result);
        }

      

       
    }
}
