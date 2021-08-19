using fabiostefani.io.CleanArch.Repository.database.ef.ModelEf;
using Microsoft.EntityFrameworkCore;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class ItemEfConfig : IEntityTypeConfiguration<ItemEf>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemEf> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

            builder.Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(x => x.Price)
            .HasColumnName("price")
            .IsRequired()
            .HasPrecision(9, 2);

            builder.Property(x => x.Height)
            .HasColumnName("height")
            .IsRequired()
            .HasPrecision(9, 2);

            builder.Property(x => x.Width)
            .HasColumnName("width")
            .IsRequired()
            .HasPrecision(9, 2);

            builder.Property(x => x.Length)
            .HasColumnName("length")
            .IsRequired()
            .HasPrecision(9, 2);

            builder.Property(x => x.Weight)
            .HasColumnName("weight")
            .IsRequired()
            .HasPrecision(9, 2);

            builder.ToTable("item");
        }
    }
}


// id serial,
//     description text,
//     price numeric,
//     height integer,
//     width integer,
//     length integer,
//     weight integer