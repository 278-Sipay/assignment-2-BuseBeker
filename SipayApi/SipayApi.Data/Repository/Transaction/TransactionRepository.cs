

using Microsoft.EntityFrameworkCore;
using SipayApi.Data;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Transaction> _dbSet;

    /*
    * "TransactionRepository" sınıfı, "GenericRepository<Transaction>" sınıfından türetilmiştir. Bu sayede, "GenericRepository"
    * sınıfının içinde bulunan işlemleri ve veritabanı yönetim fonksiyonlarını miras alır ve "Transaction" veri modeliyle kullanabilir.
    * 
    * "TransactionRepository" sınıfının yapıcısı (constructor) tanımlanmıştır. Bu yapıcı, "TransactionRepository" sınıfının örneklerinin 
    * oluşturulması sırasında çalışır. Yapıcı içinde DbContext ve DbSet nesneleri tanımlanarak, veritabanı işlemleri için gerekli nesneler oluşturulur.
    */


    public TransactionRepository(SimDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Transaction>();
    }

    // Bu metot, veritabanında "Transaction" verilerini belirli bir referans numarasına göre filtreleyerek getirir.
    public List<Transaction> GetByReference(string referenceNumber)
    {
        return _dbSet.Where(x => x.ReferenceNumber == referenceNumber).ToList();
    }

    //   Bu metot, veritabanında "Transaction" verilerini belirli bir filtreye göre getirir. Filtreleme işlemi, Lambda ifadesiyle sağlanır.
    //   Bu sayede, farklı filtreleme koşullarına göre veritabanından verileri getirmek için kullanılabilir.
    public List<Transaction> GetByParameter(Expression<Func<Transaction, bool>> filter)
    {
        return _dbSet.Where(filter).ToList();
    }

}