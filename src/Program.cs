namespace database;

public class Program
{
    public static void Main(string[] args)
    {

        Database db = new Database();
        // User_test(db);
        // Post_test(db);
        Community_test(db);

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
        int? id = db.RegisterUser("diddy69@party.cum", "TheGreatDiddler", "6969696");
        Console.WriteLine($"User registered id: {id}");

        // login fail test (wrong pwd) [passed]
        Console.WriteLine($"return: {db.LoginUser("TheGreatDiddler", "123456")}");

        // login sucsess test [passed]
        int? id2 = db.LoginUser("TheGreatDiddler", "6969696");
        Console.WriteLine($"User logged in id: {id2}");

        // login fail test (wrong user) [passed]
        Console.WriteLine($"return: {db.LoginUser("Skibidi", "bobbobS")}");

        // fetch user test fail (wrong id) [passed]
        Console.WriteLine(db.GetUser(0));


        // delete user test [passed]
        Console.WriteLine(db.DeleteUser(id));


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

    public static void Community_test(Database db)
    {
        // Create a Community test succeded  [passed]
        Console.WriteLine($"test Create Post: {db.CreateCommunity("femboy Lovers", "man i love femboy and so do you", "/com/femoys.svg", 193, "sex",101)}");

        // get Community invalid ID will fail [passed]
        Console.WriteLine($"fetch Community test: {db.GetCommunity(193)}");

        // get Community valid ID [passed]
        Console.WriteLine($"fetch Community test: {db.GetCommunity(4)}");

        // update Community user tests succeded [passed]
        Console.WriteLine($"update Community user test: {db.UpdateCommunity_User(4, "mega femboy Lovers", "man i love femboy and so do you, you submissive little femboy", "/com/femoys.svg", "sex")}");
        
        // update Community user tests succeded [passed]
        Console.WriteLine($"update Community Backend test: {db.UpdateCommunity_Backend(4, 1233454243,"sex, incest","102")}");
        
        // to see if the update fucktions work
        Console.WriteLine($"fetch Community test: {db.GetCommunity(4)}");
        
        
        // Delete community test [passed]
        Console.WriteLine($"Delete Community: {db.DeleteCommunity(4)}");
        
        
    }
}
