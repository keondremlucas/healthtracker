using System;
using Microsoft.Data.Sqlite;

namespace ClassLib
{
    public static class Sql
    {
        public static void Query()
        {
            using var connection =  new SqliteConnection("Data Source = ./data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
            SELECT * 
            FROM healthtracker";
            
            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                var id = reader.GetInt32(0);
                var dates = reader.GetString(1);
                var weights = reader.GetInt32(2);
                var bmi = reader.GetInt32(2);
                var calories = reader.GetInt32(2);

                Console.WriteLine($"Row: {id} - {dates} - {weights} - {bmi} - {calories}");
            }
        }
        public static void Insert(string dates, int weights, int bmi, int calories)
        {
            using var connection =  new SqliteConnection("Data Source = ./data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
             command.CommandText = @"
            INSERT INTO healthtracker(dates, weights, bmi ,calories)
            VALUES($dates, $weights, $bmi ,$calories)
            ";
            command.Parameters.AddWithValue("$dates",dates);
            command.Parameters.AddWithValue("$weights",weights);
            command.Parameters.AddWithValue("$bmi",bmi);
            command.Parameters.AddWithValue("$calories",calories);
            using var reader = command.ExecuteReader();
            Console.WriteLine($"Added :{reader.HasRows}");

        }

        public static void Update(int id, string dates, int weights, int bmi, int calories)
        {
            using var connection =  new SqliteConnection("Data Source = ./data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
             command.CommandText = @"
            UPDATE healthtracker
            SET id = $id , dates = $dates, weights = $weights, bmi = $bmi, calories = $calories
            WHERE id = $id
            ";
            command.Parameters.AddWithValue("$id",id);
            command.Parameters.AddWithValue("$dates",dates);
            command.Parameters.AddWithValue("$weights",weights);
            command.Parameters.AddWithValue("$bmi",bmi);
            command.Parameters.AddWithValue("$calories",calories);
            using var reader = command.ExecuteReader();
            Console.WriteLine($"Updated :{reader.HasRows}");
        }
        public static void Delete(int id)
        {
            using var connection =  new SqliteConnection("Data Source = ./data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
             command.CommandText = @"
            DELETE 
            FROM healthtracker
             WHERE id = $id;
            ";
            command.Parameters.AddWithValue("$id",id);
            using var reader = command.ExecuteReader();
            Console.WriteLine($"Deleted :{reader.HasRows}");

        }

    }
}