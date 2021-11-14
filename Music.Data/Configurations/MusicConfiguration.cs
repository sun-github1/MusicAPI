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
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            //builder
            //    .HasKey(m => m.MusicId);

            //builder
            //    .Property(m => m.MusicId)
            //    .UseIdentityColumn();

            //builder
            //    .Property(m => m.MusicName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //builder
            //    .HasOne(m => m.Artist)
            //    .WithMany(a => a.Musics)
            //    .HasForeignKey(m => m.ArtistId);

            //builder
            //    .ToTable("Musics");
        }
    }
}
