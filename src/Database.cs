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
            else
            {
                return -1;
            }
        }

        return null;
    }


    public int? RegisterUser(string email, string username, string password)
    //Registered user does not use first available ID, meaning if user.id 1 deletes account, user.id 1 will never be used again
    //RegisterUser fails returns the ID of the newly registered user
    {
        if (LoginUser(username, "dummy") != null)
        {
            return -1;
        }
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

    public int DeleteUser(int id)
    {
        SQLiteCommand command = new SQLiteCommand("DELETE FROM USER WHERE USER_ID = @id", _connection);
        command.Parameters.AddWithValue("@id", id);

        if (command.ExecuteNonQuery() > 0)
        {
            return 200;
        }
        return 207;
    }

    public int UpdateUser(int id, string img_path, string password)
    {
        SQLiteCommand command = new SQLiteCommand("UPDATE USER SET PASSWORD = @password, IMG_PATH = @img_path WHERE USER_ID = @id", _connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@img_path", img_path);

        if (command.ExecuteNonQuery() > 0)
        {
            return 200;
        }
        return 207;
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


}
