using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    //buranın configuration dosyası olduğunu IEntityTypeConfigurationu miras aldığından anlıyor
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        //Configure methodunu kullanarak product entitisinin veri tabanında nasıl oluşması gerektiğini EF' e burada öğretiyoruz
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            //navigationunuda belirtiyoruz bunu yazmasaydıkta çalışırdı çünkü entitylerimiz geleneklere uygun tanımladık

            builder.HasOne(x => x.Category) //her product ın bir tane categorisi vardır(hasone)
                .WithMany() //categorynin birden fazla productı olabilir
                .HasForeignKey(x => x.CategoryId); //foreingkey i

            builder.HasOne(x => x.Brand) //her product ın bir tane Brand i vardır(hasone)
                .WithMany() //Brandin birden fazla productı olabilir
                .HasForeignKey(x => x.BrandId); //foreingkey i




        }
    }
}
