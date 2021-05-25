using System;

namespace DesafioGuilherme.Api.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; private set; }

        public string Summary { get; set; }

        public WeatherForecast()
        {
            TemperatureF = 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
