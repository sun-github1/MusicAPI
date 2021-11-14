using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllProducers();
        Task<Producer> GetProducerById(int producerId);
        Task<Producer> AddProducer(Producer newProducer);
        Task<Producer> UpdateProducer(int producerId,Producer updatedProducer);
        Task DeleteProducer(Producer deleteProducer);
        Task<Producer> GetProducerByName(string producerName);
    }
}
