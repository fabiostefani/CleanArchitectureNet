using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class OrderEfConfig : IEntityTypeConfiguration<OrderEf>
    {
        public void Configure(EntityTypeBuilder<OrderEf> builder)
        {
            builder.ToTable("order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

            builder.Property(x => x.CouponCode)
            .HasColumnName("coupon_code")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(x => x.Code)
            .HasColumnName("code")
            .IsRequired()
            .HasMaxLength(12);

            builder.Property(x => x.Cpf)
            .HasColumnName("cpf")
            .IsRequired()
            .HasMaxLength(11);

            builder.Property(x => x.Freight)
            .HasColumnName("freight")
            .IsRequired()
            .HasPrecision(9,2);

            builder.Property(x => x.IssueDate)
            .HasColumnName("issue_date")
            .IsRequired();

            builder.Property(x => x.Sequence)
            .HasColumnName("serial")
            .IsRequired();

        }
    }
}

// create table ccca. (
// 	 serial,
// 	 text,
// 	 text,
// 	 text,
// 	 timestamp,
// 	 numeric,
// 	 integer,
// 	primary key (id)
// );

// create table ccca.order_item (
// 	id_order integer,
// 	id_item integer,
// 	price numeric,
// 	quantity integer,
// 	primary key (id_order, id_item)
// );