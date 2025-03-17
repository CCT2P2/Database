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
        if (reader.Read()) {
          return reader.GetInt16(0);
        }
        
    }

    public string GetUser(int id)
    {
        SQLiteCommand command = new SQLiteCommand("SELECT * FROM USER WHERE USER_ID = @id", _connection);
        command.Parameters.AddWithValue("@id", id);
        
        

        return "peepeepoopoo";
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