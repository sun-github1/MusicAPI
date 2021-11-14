using MusicWeb.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core
{
    public interface IRepositoryWrapper: IDisposable
    {
        IArtistRepository Artist { get; }
        IMusicRepository Music { get; }
        IProducerRepository Producer { get; }

        IArtist_MusicRepository Artist_Music { get; }
        Task<int> Save();
    }
}
