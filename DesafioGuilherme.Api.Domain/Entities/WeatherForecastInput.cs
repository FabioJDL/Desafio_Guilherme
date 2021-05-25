using DesafioGuilherme.Api.Domain.Core.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace DesafioGuilherme.Api.Domain.Entities
{
    public class WeatherForecastInput : Entity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public WeatherForecastInput(DateTime date, int temperatureC, string summary)
        {
            Date = date;

            TemperatureC = temperatureC;

            Summary = summary;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(summary, nameof(Summary), $"Field \"{nameof(Summary)}\" cannot be null or empty.")
                );
        }
    }
}
