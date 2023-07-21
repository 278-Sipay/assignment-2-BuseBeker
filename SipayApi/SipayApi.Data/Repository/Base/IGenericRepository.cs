using System.Linq.Expressions;

namespace SipayApi.Data.Repository;

/*
 * Bu arayüz, veritabanı işlemleri için kullanılacak temel metotları içerir. Farklı entity türleri için repository 
 * sınıfları oluşturulurken bu arayüzü uygulamak gerekir. Örneğin, "Transaction" veya "Customer" gibi farklı varlık 
 * türleri için ayrı ayrı repository sınıfları oluşturulabilir ve bu sınıflar "IGenericRepository" arayüzünü uygular. 
 * Bu sayede, temel veritabanı işlemleri için tekrar tekrar aynı kodu yazmaktan kaçınılır ve kodun tekrar kullanılabilirliği 
 * artar. Arayüz aynı zamanda, SOLID prensipleri ile uyumludur ve kodun bakımını ve geliştirilebilirliğini kolaylaştırır.
 */

public interface IGenericRepository<Entity> where Entity : class
{
    // Değişikliklerin veritabanına kalıcı olarak kaydedilmesi için kullanılacak metot.
    void Save();

    // Belirli bir kimlik (id) değerine sahip varlığı veritabanından getirecek metot.
    Entity GetById(int id);

    // Yeni bir varlık (entity) örneğini veritabanına eklemek için kullanılacak metot.
    void Insert (Entity entity);

    // Bir varlık örneğinin veritabanındaki karşılığını güncellemek için kullanılacak metot.
    void Update (Entity entity);

    // Belirli bir varlık (entity) örneğini veritabanından silmek için kullanılacak metot.
    void Delete (Entity entity);

    // Belirli bir kimlik (id) değerine sahip varlığı veritabanından silmek için kullanılacak metot.
    void DeleteById(int id);

    // Tüm varlık örneklerini veritabanından getirecek metot.
    List<Entity> GetAll();

    // Tüm varlık örneklerini bir IQueryable nesnesi olarak veritabanından getirecek metot.
    IQueryable<Entity> GetAllAsQueryable();

    // Belirli bir Lambda ifadesi ile veritabanındaki varlık örneklerini filtrelemek için kullanılacak metot.
    List<Entity> Where(Expression<Func<Entity, bool>> filter);
}
