[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/FSGTCrc2)
# Sipay&Patika.dev .NET Bootcamp - Case #2

Bu proje, ASP.NET 6.0 uygulamasında `TransactionController` sınıfı üzerinde bir `GetByParameter` apisi ve Query Parameter olarak 
- AccountNumber
- MinAmountCredit
- MaxAmountCredit
- MinAmountDebit
- MaxAmountDebit
- Description
- BeginDate
- EndDate
- ReferenceNumber
  filtre ozelliklerini içermektedir.

---
`TransactionController`
  
Bu kodda bir ASP.NET Core Web API projesi içinde, "TransactionController" adında bir Controller sınıfı tanımlanmıştır. Bu Controller, bir veritabanındaki Transaction verilerine erişimi yönetir. Ayrıca, AutoMapper kütüphanesi kullanılarak veritabanı nesneleri ile API yanıtları arasında dönüşüm yapmak için de kullanılmaktadır. İçerisinde `GetByParameter` bulunmaktadır. Bu metot, API isteğiyle alınan parametrelere göre veritabanından "Transaction" verilerini filtreleyerek alır, dönüştürür ve bir ApiResponse nesnesi içinde yanıt olarak döndürür. Bu sayede, belirli kriterlere uyan "Transaction" verilerine erişmek için kullanılır.

---
`ITransactionRepository`

Bu kodda bir .NET Core projesi içinde "ITransactionRepository" adında bir arayüz (interface) tanımlanmıştır. Bu arayüz, "Transaction" adında bir domain (veri modeli) sınıfını kullanarak veri tabanı işlemlerini yönetmek için kullanılan metodları içerir. Ayrıca "IGenericRepository<Transaction>" arayüzünden miras alır. İçerisinde `GetByReference` ve `GetByParameter` bulunmaktadır.

`"GetByReference"` metodu, veritabanında "Transaction" verilerini belirli bir referans numarasına göre getirmek için kullanılır.

`"GetByParameter"` metodu, veritabanında "Transaction" verilerini belirli bir filtreye göre getirmek için kullanılır. Filtreleme işlemi, Lambda ifadesiyle sağlanır. Bu metot, "Expression<Func<Transaction, bool>> filter" tipinde bir parametre alır ve bu parametreyi kullanarak veritabanından filtrelenmiş "Transaction" verilerini alır.

Arayüz, "ITransactionRepository" adında bir sözleşme (contract) sağlar. Bu sözleşmeye uygun olarak, veritabanında "Transaction" verileriyle ilgili işlemleri gerçekleştiren herhangi bir sınıf, bu arayüzdeki metotları uygulamalıdır. Böylece, farklı veri tabanı yönetim sistemi uygulamaları arasında kolaylıkla değiştirilebilir ve bu sınıfların tümü "ITransactionRepository" arayüzünden türetildiği için aynı metotları içermek zorundadır. Bu, kodun esnekliğini ve bakımını kolaylaştırır ve yeni veri tabanı işlemleri eklemek veya mevcutları değiştirmek için arayüzde belirli bir yapıyı korumayı sağlar.

---
`TransactionRepository`

Bu kodda bir .NET Core projesi içinde "TransactionRepository" adında bir sınıf tanımlanmıştır. Bu sınıf, "ITransactionRepository" arayüzünden türetilmiştir ve "Transaction" adında bir domain (veri modeli) sınıfını kullanarak veritabanı işlemlerini yönetmek için kullanılan metotları içerir. "TransactionRepository" sınıfı, "GenericRepository<Transaction>" sınıfından türetilmiştir. Bu sayede, "GenericRepository" sınıfının içinde bulunan işlemleri ve veritabanı yönetim fonksiyonlarını miras alır ve "Transaction" veri modeliyle kullanabilir.

"TransactionRepository" sınıfının yapıcısı (constructor) tanımlanmıştır. Bu yapıcı, "TransactionRepository" sınıfının örneklerinin oluşturulması sırasında çalışır. Yapıcı içinde DbContext ve DbSet nesneleri tanımlanarak, veritabanı işlemleri için gerekli nesneler oluşturulur.

"GetByReference" metodu tanımlanmıştır:
   ```
   public List<Transaction> GetByReference(string referenceNumber)
   {
       return _dbSet.Where(x => x.ReferenceNumber == referenceNumber).ToList();
   }
   ```
   Bu metot, veritabanında "Transaction" verilerini belirli bir referans numarasına göre filtreleyerek getirir.

   "GetByParameter" metodu tanımlanmıştır:
   ```
   public List<Transaction> GetByParameter(Expression<Func<Transaction, bool>> filter)
   {
       return _dbSet.Where(filter).ToList();
   }
   ```
Bu metot, veritabanında "Transaction" verilerini belirli bir filtreye göre getirir. Filtreleme işlemi, Lambda ifadesiyle sağlanır. Bu sayede, farklı filtreleme koşullarına göre veritabanından verileri getirmek için kullanılabilir.

Bu "TransactionRepository" sınıfı, "ITransactionRepository" arayüzündeki metotları uygular ve veritabanı işlemlerini "Transaction" veri modeli üzerinde yönetmek için kullanılır.

---
`GenericRepository`
Bu kodda, bir veritabanı erişim katmanı (repository) için "GenericRepository" adında bir sınıf tanımlanmıştır. Bu sınıf, bir ORM (Object-Relational Mapping) aracı olan Entity Framework Core ve Dapper kütüphanesi ile birlikte kullanılarak veritabanı işlemlerini gerçekleştirmek için kullanılır. "GenericRepository" sınıfı, "IGenericRepository<Entity>" arayüzünden türetilmiştir ve "Entity" tipindeki sınıfları kullanarak veritabanı işlemlerini yönetmek için kullanılır. Burada "Entity" tipi, "BaseModel" adında bir ana sınıftan türetilmiş olmalıdır (where Entity : BaseModel).

"GenericRepository" sınıfının yapıcısı (constructor) tanımlanmıştır. Bu yapıcı, "GenericRepository" sınıfının örneklerinin oluşturulması sırasında çalışır ve DbContext nesnesi alır. Bu nesne, Entity Framework Core ile veritabanına erişim sağlayan bağlamdır.

"Save" metodu tanımlanmıştır:
 ```  
   public void Save()
   {
       dbContext.SaveChanges();
   }
 ```
Bu metot, değişikliklerin veritabanına kalıcı olarak kaydedilmesi için DbContext'teki SaveChanges() metodunu çağırır.

"Delete" metodu tanımlanmıştır:
```
   public void Delete(Entity entity)
   {
       dbContext.Set<Entity>().Remove(entity);
   }
```   
Bu metot, belirli bir varlık (entity) örneğini veritabanından silmek için kullanılır.

"DeleteById" metodu tanımlanmıştır:
```
   public void DeleteById(int id)
   {
       var entity = dbContext.Set<Entity>().Find(id);
       Delete(entity);
   }
```   
Bu metot, belirli bir kimlik (id) değerine sahip varlığı veritabanından silmek için kullanılır.

"GetAll" metodu tanımlanmıştır:
```
   public List<Entity> GetAll()
   {
       return dbContext.Set<Entity>().ToList();
   }
```   
Bu metot, tüm varlık örneklerini veritabanından almak için kullanılır.

"GetAllAsQueryable" metodu tanımlanmıştır:
```
   public IQueryable<Entity> GetAllAsQueryable()
   {
       return dbContext.Set<Entity>().AsQueryable();
   }
```   
Bu metot, tüm varlık örneklerini bir IQueryable nesnesi olarak veritabanından almak için kullanılır.

"GetById" metodu tanımlanmıştır:
```
    public Entity GetById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        return entity;
    }
```    
Bu metot, belirli bir kimlik (id) değerine sahip varlığı veritabanından almak için kullanılır.

"Insert" metodu tanımlanmıştır:
```
    public void Insert(Entity entity)
    {
        entity.InsertDate = DateTime.UtcNow;
        entity.InsertUser = "simadmin@pay.com";
        dbContext.Set<Entity>().Add(entity);
    }
```    
Bu metot, yeni bir varlık örneğini veritabanına eklemek için kullanılır. Ayrıca, InsertDate ve InsertUser gibi bazı alanlar için varsayılan değerler atanır.

"Update" metodu tanımlanmıştır:
```
    public void Update(Entity entity)
    {
        dbContext.Set<Entity>().Update(entity);
    }
```    
Bu metot, bir varlık örneğinin veritabanındaki karşılığını güncellemek için kullanılır.

"Where" metodu tanımlanmıştır:
```
    public List<Entity> Where(Expression<Func<Entity, bool>> filter)
    {
        return dbContext.Set<Entity>().Where(filter).ToList();
    }
```    
Bu metot, belirli bir Lambda ifadesi ile veritabanındaki varlık örneklerini filtrelemek için kullanılır. Filtreleme işlemi, Expression<Func<Entity, bool>> tipindeki bir parametre ile sağlanır.

---
`TransactionRepository`

Bu kodda bir .NET Core projesinde "IGenericRepository" adında bir arayüz (interface) tanımlanmıştır. Bu arayüz, veritabanı erişim katmanındaki repository sınıfları için genel olarak kullanılabilecek temel operasyonların (CRUD - Create, Read, Update, Delete) sözleşmesini (contract) belirler. Bu sayede, farklı entity türleriyle çalışan repository sınıflarının aynı arayüzü uygulamaları sağlanır.

Bu arayüz, veritabanı işlemleri için kullanılacak temel metotları içerir. Farklı entity türleri için repository sınıfları oluşturulurken bu arayüzü uygulamak gerekir. Örneğin, "Transaction" veya "Customer" gibi farklı varlık türleri için ayrı ayrı repository sınıfları oluşturulabilir ve bu sınıflar "IGenericRepository" arayüzünü uygular. Bu sayede, temel veritabanı işlemleri için tekrar tekrar aynı kodu yazmaktan kaçınılır ve kodun tekrar kullanılabilirliği artar. Arayüz aynı zamanda, SOLID prensipleri ile uyumludur ve kodun bakımını ve geliştirilebilirliğini kolaylaştırır.
