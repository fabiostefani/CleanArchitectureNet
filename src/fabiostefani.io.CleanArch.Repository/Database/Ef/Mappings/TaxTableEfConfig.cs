using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class TaxTableEfConfig : IEntityTypeConfiguration<TaxTableEf>
    {
        public void Configure(EntityTypeBuilder<TaxTableEf> builder)
        {
            builder.ToTable("")
        }
    }
}