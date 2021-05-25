using AutoMapper;
using DesafioGuilherme.Api.Domain.Entities;
using DesafioGuilherme.Api.Domain.Models;

namespace DesafioGuilherme.Api.Application.Mapping
{
    public class WeatherforecastMap : Profile
    {
        public WeatherforecastMap()
        {
            //CreateMap<WeatherForecast, WeatherForecastModel>();
            CreateMap<WeatherForecast, WeatherForecastModel>();
        }
    }
}
