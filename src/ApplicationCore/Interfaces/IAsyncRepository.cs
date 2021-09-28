using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{                            
                                         /*Constraint(kısıtlama) içine girebilecek veri türü base class dan miras almış olmalı*/
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        //(metotlar uygulanırken hangi teknolojiyi kullandığı bizi bağlamıyor infrada belirlenin rahatlıkla değiştirebilmek için interface yapısını kullanıyoruz.)

        //Veriyi Id ye göre Getirme
        Task<T> GetById(int Id);

        // T türü seçilen verinin bütün listesini döndürür.
        Task<List<T>> ListAllAsync();

        // T türü seçilen veriyi belirttiğimiz filitreye göre listeler.
        Task<List<T>> ListAsync(ISpecification<T> specification);

        // T türü seçilen ürünü DB'e ekler ve ürünün kendisini geri döndürür çünkü eklediğimiz ürünün Id sini bilmiyoruz otomatik üretiliyor geri döndürülmesi bize fayda sağlıyor.
        Task<T> AddAsync(T entity);

        //T türünde verilen parametreyi günceller.
        Task UpdateAsync(T entity);

        //T türünde verilen parametreyi DB den siler.
        Task DeleteAsync(T entity);

        // verilerin sayısını alabiliyoruz ama burada da specification ekleyebiliyoruz
        // EXP: Adı "A" ile başlayan ürünlerin sayısı diyebileceğiz.
        Task CountAsync(ISpecification<T> specification);

        //Specification sartına uyan ilk veriyi getirecek.
        Task FirstAsync(ISpecification<T> specification);

        //Specification sartına uyan ilk veriyi getirecek bulamazsa hata vermeyip default değeri gönderecek.
        Task FirsOrDefaulttAsync(ISpecification<T> specification);





    }
}
