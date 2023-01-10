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
    public class TrackConfiguration : IEntityTypeConfiguration<TrackModel>
    {
        public void Configure(EntityTypeBuilder<TrackModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.TrackDetail)
                .WithOne(x => x.Track);

                
        }
     }
}
