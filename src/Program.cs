namespace database;

public class Program
{
    public static void Main(string[] args)
    {

        Database db = new Database();
        User_test(db);
        Post_test(db);

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

    public static void User_test(Database db) // [passed]
    {
        // register test [passed]
        // int? id = db.RegisterUser("diddy69@party.cum", "TheGreatDiddler", "6969696");
        // Console.WriteLine($"User registered id: {id}");

        // login fail test (wrong pwd) [passed]
        // Console.WriteLine($"return: {db.LoginUser("TheGreatDiddler", "123456")}");

        // login sucsess test [passed]
        // int? id = db.LoginUser("TheGreatDiddler", "6969696");
        // Console.WriteLine($"User logged in id: {id}");

        // login fail test (wrong user) [passed]
        // Console.WriteLine($"return: {db.LoginUser("Skibidi", "bobbobS")}");

        // fetch user test fail (wrong id) [passed]
        //Console.WriteLine(db.GetUser(0));


        // delete user test [passed]
        // Console.WriteLine(db.DeleteUser(12));

      
    }

    public static void Post_test(Database db)
    {
        // Create Post test succeded  [passed]
        Console.WriteLine($"test Create Post: {db.CreatePost("man shitter","i love The Great Diddler he do be diddleing me",1,3,null,false)}");
        
        // fetch Post test succeded [passed]
        Console.WriteLine($"fetch Post test: {db.GetPost(106)}");
        
        
        // update Post tests succeded [passed]
        Console.WriteLine($"update Post Test (User): {db.updatePostUser(106,"shitter man (Gone SEXUAL!!!!!??!?!!?!?)", "i love The Great Diddler he do be diddleing me in my little bumbum")}");
        Console.WriteLine($"update Post Test (Backend): {db.updatePostBackend(106, 100324, "1,2,3,4",11345234,69420)}");
        
        // fetch Post test to see if the update Post fucktions work [passed]
        Console.WriteLine($"fetch Post after update tests to see if they worked: {db.GetPost(106)}");
        
        // Delete Post tests succeded [passed]
        Console.WriteLine($"Delete User test: {db.DeletePost(106)}");
    }
}
