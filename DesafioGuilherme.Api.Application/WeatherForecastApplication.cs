using AutoMapper;
using DesafioGuilherme.Api.Application.Interfaces;
using DesafioGuilherme.Api.Application.Results;
using DesafioGuilherme.Api.Domain.Entities;
using DesafioGuilherme.Api.Domain.Repositories.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioGuilherme.Api.Application
{
    public class WeatherForecastApplication : Notifiable<Notification>, IWeatherForecastApplication
    {
        private readonly IMapper _mapper;

        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastApplication(IMapper mapper, IWeatherForecastRepository weatherForecastRepository)
        {
            _mapper = mapper;

            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result<IEnumerable<WeatherForecast>>> GetAsync()
        {
            var weatherForeCastList = await _weatherForecastRepository.SelectAllAsync();

            return Result<IEnumerable<WeatherForecast>>.Ok(weatherForeCastList);
        }
    }
}
