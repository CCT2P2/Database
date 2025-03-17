using System;
using System.Data;
using System.Data.SQLite;

namespace database;

public class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=src/GNUF.sqlite;Version=3;");
        OpenConnection();
    }

    private void OpenConnection()
    {
        _connection.Open();
        if (_connection.State == ConnectionState.Open)
        {
            Console.WriteLine("Connected to database successfully");
        }
        else
        {
            Console.WriteLine("Failed to connect to database");
        }
    }

    public int? LoginUser(string username, string password)
    {
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM USER WHERE USER_NAME = @username", _connection);
        command.Parameters.AddWithValue("@username", username);
        SQLiteDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            if (password == reader.GetString(3))
            {
                return reader.GetInt32(0);
            }
        }

        return null;
    }


    public int? RegisterUser(string email, string username, string password)
    {
        SQLiteCommand command = new SQLiteCommand("INSERT INTO USER (EMAIL, USER_NAME, PASSWORD) VALUES (@email, @username, @password)", _connection);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);


        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return reader.GetInt16(0);
        }
        return null;
    }

    public string? GetUser(int id)
    {
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM USER WHERE USER_ID = @id", _connection);
        command.Parameters.AddWithValue("@id", id);

        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            int ID = reader.GetInt16(0); 
            string email = reader.GetString(1);
            string username = reader.GetString(2);
            string? img_path = reader.GetString(4);//
            string? post_IDS = reader.GetString(5);//
            string? COMM_IDS = reader.GetString(6);//
            string? tags = reader.GetString(8);//
            bool admin = reader.GetBoolean(7);

            return $"{{USER_ID: {ID}EMAIL: {email}, USERNAME: {username}, IMG_PATH: {img_path}, POST_IDS: {post_IDS}, COMM_IDS: {COMM_IDS}, tags: {tags}, admin: {admin} }}";
        }
        return null;
    }

    public int CreateCommunity(string name, string tags, string description, string? imagePath)
    {
        SQLiteCommand command = new SQLiteCommand("INSERT INTO COMMUNITY (COMMUNITY_NAME, TAGS, COMMUNITY_DESCRIPTION, IMAGE_PATH) VALUES (@name, @tags, @description, @imagePath)", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@tags", tags);
        command.Parameters.AddWithValue("@description", description);
        command.Parameters.AddWithValue("@imagePath", imagePath);

        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
    public void GetPost(int id)
    {
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM POSTS", _connection);
        SQLiteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int postId = reader.GetInt16(0); // or reader["Id"]
            string title = reader.GetString(1); // or reader["Title"]
            string content = reader.GetString(2); // or reader["Content"]

            Console.WriteLine($"ID: {postId}, Title: {title}, Content: {content}");
        }

        reader.Close();
    }

    private int GetUserIDs()
    {
        List<int> ids = new List<int>();
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM USER", _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            ids.Add(reader.GetInt32(0));
        }
        int temp = 0;
        if (ids.Count == 0)
        {
            throw new Exception("No users found in the database.");
        } 
        foreach (int id in ids)
        {
            if (id == temp + 1)
            {
                temp = id;
            }
            else
            {
                break;
            }
        }
        return temp;
    }
    
    private int GetCommIDs()
    {
        List<int> ids = new List<int>();
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM COMMUNITY", _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            ids.Add(reader.GetInt32(0));
        }
        int temp = 0;
        if (ids.Count == 0)
        {
            throw new Exception("No users found in the database.");
        } 
        foreach (int id in ids)
        {
            if (id == temp + 1)
            {
                temp = id;
            }
            else
            {
                break;
            }
        }
        return temp;
    }
    
    public int GetPostIDs()
    {
        List<int> ids = new List<int>();
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM POSTS", _connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            ids.Add(reader.GetInt32(0));
        }
        int temp = 100;
        if (ids.Count == 0)
        {
            throw new Exception("No users found in the database.");
        } 
        foreach (int id in ids)
        {
            if (id == temp + 1)
            {
                temp = id;
            }
            else
            {
                break;
            }
        }
        return temp;
    }

}
