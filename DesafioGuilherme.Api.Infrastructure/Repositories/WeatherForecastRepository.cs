using DesafioGuilherme.Api.Domain.Entities;
using DesafioGuilherme.Api.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioGuilherme.Api.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        public Task AddAsync(WeatherForecast obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WeatherForecast> GetByCondition(Expression<Func<WeatherForecast, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WeatherForecast>> SelectAllAsync()
        {
            var rng = new Random();

            IEnumerable<WeatherForecast> wfList = null;

            await Task.Run(() =>
            {
                wfList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });
            });

            return wfList;
        }

        public Task<WeatherForecast> SelectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WeatherForecast obj)
        {
            throw new NotImplementedException();
        }
    }
}
