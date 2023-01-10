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
    public class ArtistConfiguration : IEntityTypeConfiguration<ArtistModel>
    {
        public void Configure(EntityTypeBuilder<ArtistModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
