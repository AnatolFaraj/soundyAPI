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
    public class CredentialsConfiguration : IEntityTypeConfiguration<CredentialsModel>
    {
        public void Configure(EntityTypeBuilder<CredentialsModel> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Credential)
                .HasForeignKey<CredentialsModel>(x => x.UserId);

        }
    }
}
