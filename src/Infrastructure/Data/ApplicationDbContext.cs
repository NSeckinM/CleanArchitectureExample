using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Db setlere categori gibi türleri ekleyebilmemiz için  Infrastructure ın referanslarına applicationcore u eklemeliyiz çünkü Entitylerimiz applicationcore da.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //entitylerimiz içi DB'de model create edilirken fluentapi ile validasyonlarımızı burada tek tek oluşturabiliriz ama tek tek hepsine burada yazmak bu sayfayı kalabalıklaştıracak ve mimarimizi etkileyeceğinden dolayı biz bunları ayırarak config klasörü içerisinde tanımlayacağız ama yinede geçerli olmaları için hepsini tek tek usingle buraya şöyle eklememiz gerek işte bu işlemi bize aşağıdaki satır sağlıyor.
            //Aynı DLL altındaki Configuration dosyalarını gezip içeriklerini etkin kılıyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        //25. satır peki bir klasörün configüre dosyası olduğunu nasıl anlıyor?
        //=> configuration dosyası olduğunu IEntityTypeConfigurationu miras aldığından anlıyor

        //25. satır yerine her configuration clasını böyle de tek tek ekliyebiliriz 
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());




    }
}
