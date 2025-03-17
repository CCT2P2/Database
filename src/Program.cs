namespace database;

public class Program
{
    public static void Main(string[] args)
    {

        Database db = new Database();
        User_test(db);

        /*
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        /*

        /* var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = summaries[Random.Shared.Next(summaries.Length)]
                        })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast"); */

        // app.Run();
    }

    public static void User_test(Database db)
    {
        // register test
        int? id = db.RegisterUser("diddy69@party.cum", "TheGreatDiddler", "6969696");
        Console.WriteLine(id);

        // login fail test (wrong pwd)
        //Console.WriteLine(db.LoginUser("TheGreatDiddler", "123456"));

        // login sucsess test
        id = db.LoginUser("TheGreatDiddler", "6969696");
        Console.WriteLine(id);

        // login fail test (wrong user)
        //Console.WriteLine(db.LoginUser("Skibidi", "bobbobS"));

        // fetch user test fail (wrong id)
        //Console.WriteLine(db.GetUser(0));


        // fetch user test success
        //Console.WriteLine(db.GetUser(1));

        //user deletion test
        Console.WriteLine(db.DeleteUser(id));
    }
}
