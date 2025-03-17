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
        Console.WriteLine(db.RegisterUser("diddy69@party.cum", "TheGreatDiddler", "6969696"));
        // fail
        Console.WriteLine(db.LoginUser("TheGreatDiddler", "123456"));

        // sucsess
        Console.WriteLine(db.LoginUser("TheGreatDiddler", "6969696"));

        // fail (but different) no user found
        Console.WriteLine(db.LoginUser("Skibidi", "bobbobS"));

        // fail
        Console.WriteLine(db.GetUser(0));


        // sucsess
        Console.WriteLine(db.GetUser(1));

        Console.WriteLine(db.DeleteUser(12));

        Console.WriteLine(db.CreatePost("man shitter","i love The Great Diddler he do be diddleing me",1,3,null,false));
        Console.WriteLine(db.GetPost(106));
        Console.WriteLine(db.updatePostUser(106,"shitter man (Gone SEXUAL!!!!!??!?!!?!?)", "i love The Great Diddler he do be diddleing me in my little bumbum"));
        Console.WriteLine(db.updatePostBackend(106, 100324, "1,2,3,4",11345234,69420));
        Console.WriteLine(db.GetPost(106));
        
        Console.WriteLine(db.DeletePost(106));
    }
}
