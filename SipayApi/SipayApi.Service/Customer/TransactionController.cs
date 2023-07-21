
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using SipayApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


/*
 * Bu kodda bir ASP.NET Core Web API projesi içinde, "TransactionController" adında bir Controller sınıfı tanımlanmıştır. 
 * Bu Controller, bir veritabanındaki Transaction verilerine erişimi yönetir. Ayrıca, AutoMapper kütüphanesi kullanılarak 
 * veritabanı nesneleri ile API yanıtları arasında dönüşüm yapmak için de kullanılmaktadır.
 */

namespace SipayApi.Service
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        private readonly IMapper mapper;

        public TransactionController(ITransactionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // Yeni API - GetByParameter
        [HttpGet("GetByParameter")]
        public ApiResponse<List<TransactionResponse>> GetByParameter(int? accountNumber, decimal? minAmountCredit,
            decimal? maxAmountCredit, decimal? minAmountDebit, decimal? maxAmountDebit, string description,
            DateTime? beginDate, DateTime? endDate, string referenceNumber)
        {
            // Metot içerisinde belirli kriterlere göre verileri filtrelemek için bir ifade oluşturulmuştur.
            Expression<Func<Transaction, bool>> filter = x =>
                (!accountNumber.HasValue || x.AccountNumber == accountNumber.Value) &&
                (!string.IsNullOrEmpty(referenceNumber) || x.ReferenceNumber == referenceNumber) &&
                (!minAmountCredit.HasValue || x.CreditAmount >= minAmountCredit.Value) &&
                (!maxAmountCredit.HasValue || x.CreditAmount <= maxAmountCredit.Value) &&
                (!minAmountDebit.HasValue || x.DebitAmount >= minAmountDebit.Value) &&
                (!maxAmountDebit.HasValue || x.DebitAmount <= maxAmountDebit.Value) &&
                (string.IsNullOrEmpty(description) || x.Description.Contains(description)) &&
                (!beginDate.HasValue || x.TransactionDate >= beginDate.Value) &&
                (!endDate.HasValue || x.TransactionDate <= endDate.Value);

            // Veritabanından verileri yukarıdaki filtreye göre almak için repository.GetByParameter() metodu kullanılmıştır.
            var entityList = repository.GetByParameter(filter);

            // AutoMapper ile veritabanı nesneleri "Transaction" Response nesnelerine dönüştürülüyor.
            var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);

            // Dönüştürülen veriler ApiResponse sınıfı ile birlikte dönüş olarak hazırlanıyor ve gönderiliyor.
            return new ApiResponse<List<TransactionResponse>>(mapped);
        }

        /*
         * Bu metot, API isteğiyle alınan parametrelere göre veritabanından "Transaction" verilerini filtreleyerek alır, 
         * dönüştürür ve bir ApiResponse nesnesi içinde yanıt olarak döndürür. Bu sayede, belirli kriterlere uyan "Transaction" 
         * verilerine erişmek için kullanılır.
         */
    }
}