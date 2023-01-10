using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Configurations
{
    public class TrackDetailConfiguration : IEntityTypeConfiguration<TrackDetailModel>
    {
        public void Configure(EntityTypeBuilder<TrackDetailModel> builder)
        {
            builder.HasKey(k => k.TrackId);

            builder.HasOne(x => x.Track)
                .WithOne(x => x.TrackDetail)
                .HasForeignKey<TrackDetailModel>(k => k.TrackId);
        }    }
}
