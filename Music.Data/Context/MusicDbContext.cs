using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Core.Models;
using MusicWeb.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Data.Context
{
    //public class MusicDbContext: DbContext
    public class MusicDbContext: IdentityDbContext<User, Role, Guid>
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options):base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }

        public DbSet<Artist_Music> Artist_Musics { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder
            //    .ApplyConfiguration(new MusicConfiguration());

            //builder
            //    .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}

