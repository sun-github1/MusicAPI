using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Repositories
{
    public interface IProducerRepository : IRepository<Producer>
    {
        Task<IEnumerable<Producer>> GetAllWithProducers();
        Task<Producer> GetWithProducerById(int id);
        Task<Producer> GetProducerByName(string producerName);
    }
}
