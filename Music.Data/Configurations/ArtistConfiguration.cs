using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            //builder
            //    .HasKey(a => a.ArtistId);

            //builder
            //    .Property(m => m.ArtistId)
            //    .UseIdentityColumn();

            //builder
            //    .Property(m => m.ArtistName)
            //    .IsRequired()
            //    .HasMaxLength(500);

            //builder
            //    .ToTable("Artists");
        }
    }
}
