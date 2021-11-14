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
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;

        public ProducersController(IProducerService producerService, IMapper mapper)
        {
            this._producerService = producerService;
            this._mapper = mapper;
        }
        // GET: api/<ProducersController>
        [HttpGet("get-all-producers")]
        //TODO: search by conditions to be added
        public async Task<ActionResult<IEnumerable<ProducerResultDTO>>> GetAllPublishers()
        {
            try
            {
                var allproducers = await _producerService.GetAllProducers();
                var result = _mapper.Map<IEnumerable<ProducerResultDTO>>(allproducers);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load Producers");
            }
        }

        // GET api/<ProducersController>/5
        [HttpGet("get-producer-by-id/{id}")]
        public async Task<ActionResult<ProducerResultDTO>> GetProducerById(int id)
        {
            try
            {
                var producer = await _producerService.GetProducerById(id);
                var result = _mapper.Map<ProducerResultDTO>(producer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load Producer");
            }
        }

        // POST api/<ProducersController>
        [HttpPost("add-producer")]
        public async Task<ActionResult<ProducerDTO>> AddProcuder([FromBody] ProducerAddEditDTO producerToAdd)
        {
            if (producerToAdd == null)
            {
                return BadRequest();
            }
            var producer = _mapper.Map<Producer>(producerToAdd);
            var producerwithsamename = await _producerService.GetProducerByName(producer.ProducerName);

            if (producerwithsamename != null)
            {
                ModelState.AddModelError("ProducerName", "Producer with same name alreday exists");
                return BadRequest(ModelState);
            }

            var addedproducer = await _producerService.AddProducer(producer);
            if (addedproducer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Music");
            }
            else
            {
                //Add a Location header to the response. The Location header specifies the URI of the newly created employee object
                return CreatedAtAction(nameof(GetProducerById),
                    new { id = addedproducer.ProducerId },
                    addedproducer);
            }
        }

        // PUT api/<ProducersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProducersController>/5
        [HttpDelete("delete-producer-by-id/{id}")]
        public async Task<ActionResult> Delete(int publisherid)
        {
            if (publisherid <= 0)
            {
                return BadRequest();
            }

            var existingProducer= await _producerService.GetProducerById(publisherid);

            if (existingProducer == null)
            {
                return NotFound($"Producer with id {publisherid} not found for deletion");
            }

            await _producerService.DeleteProducer(existingProducer);

            return Ok();
        }
    }
}
