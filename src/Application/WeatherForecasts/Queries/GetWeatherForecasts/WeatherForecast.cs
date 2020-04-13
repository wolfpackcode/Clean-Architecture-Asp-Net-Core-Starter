using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.WeatherForecasts.Queries.GetWeatherForecasts
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
