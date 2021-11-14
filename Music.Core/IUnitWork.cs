using MusicWeb.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core
{
    public interface IUnitWork: IDisposable
    {
        IArtistRepository ArtistRepository { get; }
        IMusicRepository MusicRepository { get; }
        Task<int> CommitAsync();
    }
}
