using DesafioGuilherme.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioGuilherme.Api.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : WeatherForecast
    {
        Task AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task RemoveAsync(int id);

        Task<T> SelectByIdAsync(int id);

        Task<IEnumerable<T>> SelectAllAsync();

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
