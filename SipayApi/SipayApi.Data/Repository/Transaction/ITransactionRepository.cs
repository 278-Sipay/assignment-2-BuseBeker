using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    //IGenericRepository<Transaction> arayüzünden miras alınmıştır.

    // "GetByReference" metodu, veritabanında "Transaction" verilerini referans numarasına göre getirir.

    List<Transaction> GetByReference(string reference);

    // "GetByParameter" metodu, veritabanında "Transaction" verilerini belirli bir filtreye göre getirir.
    // Expression<Func<Transaction, bool>> filter parametresi, filtreleme için Lambda ifadesini alır.
    List<Transaction> GetByParameter(Expression<Func<Transaction, bool>> filter);


    /*
     *  "GetByReference" metodu, veritabanında "Transaction" verilerini belirli bir referans numarasına göre getirmek için kullanılır. 
     *  "GetByParameter" metodu, veritabanında "Transaction" verilerini belirli bir filtreye göre getirmek için kullanılır. 
     *  Filtreleme işlemi, Lambda ifadesiyle sağlanır. Bu metot, "Expression<Func<Transaction, bool>> filter" tipinde bir parametre alır 
     *  ve bu parametreyi kullanarak veritabanından filtrelenmiş "Transaction" verilerini alır.
     *  
     *  Arayüz, "ITransactionRepository" adında bir sözleşme (contract) sağlar. Bu sözleşmeye uygun olarak, veritabanında "Transaction" verileriyle 
     *  ilgili işlemleri gerçekleştiren herhangi bir sınıf, bu arayüzdeki metotları uygulamalıdır. Böylece, farklı veri tabanı yönetim sistemi 
     *  uygulamaları arasında kolaylıkla değiştirilebilir ve bu sınıfların tümü "ITransactionRepository" arayüzünden türetildiği için aynı metotları 
     *  içermek zorundadır. Bu, kodun esnekliğini ve bakımını kolaylaştırır ve yeni veri tabanı işlemleri eklemek veya mevcutları değiştirmek için 
     *  arayüzde belirli bir yapıyı korumayı sağlar.
     */
}

