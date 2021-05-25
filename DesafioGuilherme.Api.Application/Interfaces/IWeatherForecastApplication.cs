using DesafioGuilherme.Api.Application.Results;
using DesafioGuilherme.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioGuilherme.Api.Application.Interfaces
{
    public interface IWeatherForecastApplication
    {
        public Task<Result<IEnumerable<WeatherForecast>>> GetAsync();
    }
}
