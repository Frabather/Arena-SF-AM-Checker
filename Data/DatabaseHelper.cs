using Arena_SF_AM_Checker.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Arena_SF_AM_Checker
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            // Ścisłe wskazanie katalogu z plikiem EXE (nawet po PublishSingleFile)
            var exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            var dbPath = Path.Combine(Path.GetDirectoryName(exePath!)!, "data.db");
            _connectionString = $"Data Source={dbPath};Version=3;";

            EnsureTableExists();
            SeedDatabase();
        }

        private void EnsureTableExists()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Entities (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    IsChecked INTEGER NOT NULL
                );";
            cmd.ExecuteNonQuery();
        }

        public void SeedDatabase()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            // Sprawdź, czy tabela zawiera dane
            var count = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM Entities");
            if (count > 0) return;

            // Lista nazw do seedowania
            var names = new[]
            {
            "Seats 25", "Seats 50", "Popcorn 25", "Seats 100", "Popcorn 50", "Popcorn 100",
            "Parking 25", "Parking 50", "Seats 250", "Parking 100", "Trap 25", "Popcorn 250",
            "Trap 50", "Trap 100", "Drink 25", "Parking 250", "Drink 50", "Drink 100",
            "Deadly 25", "Seats 500", "Trap 250", "Deadly 50", "Popcorn 500", "Deadly 100",
            "VIP 25", "Drink 250", "VIP 50", "Parking 500", "VIP 100", "Snack 25",
            "Deadly 250", "Snack 50", "Trap 500", "Snack 100", "Monster 25", "VIP 250",
            "Monster 50", "Drink 500", "Monster 100", "Toilet 25", "Snack 250", "Toilet 50",
            "Deadly 500", "Toilet 100", "Seats 1000", "Monster 250", "Popcorn 1000", "VIP 500",
            "Toilet 250", "Parking 1000", "Snack 500", "Trap 1000", "Monster 500", "Drink 1000",
            "Toilet 500", "Deadly 1000", "VIP 1000", "Snack 1000", "Monster 1000", "Toilet 1000",
            "Seats 2500", "Popcorn 2500", "Parking 2500", "Trap 2500", "Drink 2500", "Deadly 2500",
            "VIP 2500", "Snack 2500", "Monster 2500", "Toilet 2500"
            };

            // Wstaw dane
            foreach (var name in names)
            {
                conn.Execute("INSERT INTO Entities (Name, IsChecked) VALUES (@Name, 0)", new { Name = name });
            }
        }


        public IEnumerable<MyEntity> GetAll()
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.Query<MyEntity>("SELECT * FROM Entities");
        }

        public void UpdateChecked(int id, bool isChecked)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute("UPDATE Entities SET IsChecked = @isChecked WHERE Id = @id", new { id, isChecked });
        }
    }
}
