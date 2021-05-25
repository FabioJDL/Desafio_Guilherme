using AutoMapper;
using DesafioGuilherme.Api.Application.Interfaces;
using DesafioGuilherme.Api.Domain.Models;
using DesafioGuilherme.Api.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGuilherme.Api.Api.Controllers
{
    [ApiController]
    [Route(Constants.Routs.WeatherForecast)]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastApplication _weatherForecastApplication;

        private readonly IMapper _mapper;

        public WeatherForecastController(IWeatherForecastApplication weatherForecastApplication, IMapper mapper)
        {
            _weatherForecastApplication = weatherForecastApplication;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _weatherForecastApplication.GetAsync();

            if (!result.Success)
            {
                if (result.Notifications.Any(_notification => _notification.Message.Equals("")))
                    return BadRequest(result.Notifications);

                //return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<WeatherForecastModel>>(result.Object));
        }
    }
}
