namespace WebApplicationTechLead1
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


public static class WeatherForecastEndpoints
{
	public static void MapWeatherForecastEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/WeatherForecast", () =>
        {
            return new [] { new WeatherForecast() };
        })
        .WithName("GetAllWeatherForecasts")
        .Produces<WeatherForecast[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/WeatherForecast/{id}", (int id) =>
        {
            //return new WeatherForecast { ID = id };
        })
        .WithName("GetWeatherForecastById")
        .Produces<WeatherForecast>(StatusCodes.Status200OK);

        routes.MapPut("/api/WeatherForecast/{id}", (int id, WeatherForecast input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateWeatherForecast")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/WeatherForecast/", (WeatherForecast model) =>
        {
            //return Results.Created($"//api/WeatherForecasts/{model.ID}", model);
        })
        .WithName("CreateWeatherForecast")
        .Produces<WeatherForecast>(StatusCodes.Status201Created);

        routes.MapDelete("/api/WeatherForecast/{id}", (int id) =>
        {
            //return Results.Ok(new WeatherForecast { ID = id });
        })
        .WithName("DeleteWeatherForecast")
        .Produces<WeatherForecast>(StatusCodes.Status200OK);
    }
}}