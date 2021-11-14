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
    public class ProducerService : IProducerService
    {
        private readonly IRepositoryWrapper _repositoryWrapper; 
        public ProducerService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }
        public async Task<IEnumerable<Producer>> GetAllProducers()
        {
            return await _repositoryWrapper.Producer.GetAllWithProducers();
        }

        public async Task<Producer> GetProducerById(int producerId)
        {
            return await _repositoryWrapper.Producer.GetWithProducerById(producerId);
        }

       
        

        public async Task DeleteProducer(Producer deleteProducer)
        {
            _repositoryWrapper.Producer.Remove(deleteProducer);
            await _repositoryWrapper.Save();
        }

        public async Task<Producer> AddProducer(Producer newProducer)
        {
            var result = await _repositoryWrapper.Producer.AddAsync(newProducer);
            await _repositoryWrapper.Save();
            return result;
        }

        public async Task<Producer> UpdateProducer(int producerId, Producer updatedProducer)
        {
            var producerToBeUpdated = await _repositoryWrapper.Producer.GetById(producerId);
            producerToBeUpdated.ProducerName = updatedProducer.ProducerName;

            //artistToBeUpdated.Mus = updatedArtist.ArtistName;
            await _repositoryWrapper.Save();
            return producerToBeUpdated;
        }

        public async Task<Producer> GetProducerByName(string producerName)
        {
            return await _repositoryWrapper.Producer.GetProducerByName(producerName);
        }
    }
}
