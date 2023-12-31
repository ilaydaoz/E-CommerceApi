﻿using E_CommerceApi.Shared.Entities;
using System.Linq.Expressions;

namespace E_CommerceApi.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
//IQueryable : veritabanı sorguları daha verimli ve dinamik bir şekilde oluşturulabilir.
//ve verileri çekme, filtreleme, sıralama ve gruplama gibi işlemleri  optimize edilebilir.

//tracking :veritabanı işlemleri sırasında ilişkili  nesnelerin değişikliklerini takip etmek için kullanılır.