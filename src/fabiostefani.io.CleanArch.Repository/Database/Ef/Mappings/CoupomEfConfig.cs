using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class CoupomEfConfig : IEntityTypeConfiguration<CoupomEf>
    {
        public void Configure(EntityTypeBuilder<CoupomEf> builder)
        {
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.Percentage)
            .HasColumnName("percentage")            
            .IsRequired();

            builder.Property(x => x.ExpireDate)
            .HasColumnName("expire_date")            
            .IsRequired();

            builder.ToTable("coupon");
        }
    }
}