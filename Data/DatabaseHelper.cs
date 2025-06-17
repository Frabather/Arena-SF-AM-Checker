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

            var existingTables = conn.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name='Entities';");
            if (existingTables.Any())
            {
                var newTableExists = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='ArenaUpgrades';");

                if (newTableExists == 0)
                {
                    conn.Execute("ALTER TABLE Entities RENAME TO ArenaUpgrades;");
                }
            }

            conn.Execute(@"
                CREATE TABLE IF NOT EXISTS ArenaUpgrades (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    IsChecked INTEGER NOT NULL
                );
            ");


            conn.Execute(@"
                CREATE TABLE IF NOT EXISTS UndergroundUpgrades (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    IsChecked INTEGER NOT NULL
                );
            ");

            conn.Execute(@"
                CREATE TABLE IF NOT EXISTS LastSacrificeDate (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    LastSacrifice DateTime
                );
            ");

            conn.Execute(@"
                CREATE TABLE IF NOT EXISTS AppConfiguration (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ParamName TEXT,
                    FlgStatus INTEGER NOT NULL
                );
            ");

            conn.Execute(@"
                CREATE TABLE IF NOT EXISTS TwitchDropStatus (
                    DropDate TEXT PRIMARY KEY,
                    IsDone INTEGER NOT NULL
                );
            ");
        }


        public void SeedDatabase()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var countArena = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM ArenaUpgrades");
            if (countArena == 0)
            {
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

                foreach (var name in names)
                {
                    conn.Execute("INSERT INTO ArenaUpgrades (Name, IsChecked) VALUES (@Name, 0)", new { Name = name });
                }
            }


            /////////////////      UndergroundUpgrades


            var countUnder = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM UndergroundUpgrades");
            if (countUnder == 0)
            {
                var names2 = new[]
                {
                "Heart 1", "Extractor 1", "Goblin 1", "Heart 2", "Gate 1", "Gate 2", "Extractor 2", "Heart 3", "Extractor 3", "Gate 3", "Torture 1", "Heart 4",
                "Extractor 4", "Gate 4", "Gladiator 1", "Heart 5", "Extractor 5", "Gate 5", "Keeper 1", "Keeper 2", "Keeper 3", "Adventure 1", "Torture 2",
                "Adventure 2", "Gladiator 2", "Gladiator 3", "Torture 3", "Heart 6", "Extractor 6", "Gate 6", "Keeper 4", "Gladiator 4", "Gladiator 5",
                "Adventure 3", "Adventure 4", "Torture 4", "Goldpit 1", "Goldpit 2", "Goldpit 3", "Goldpit 4", "Goldpit 5", "Heart 7", "Extractor 7", "Gate 7",
                "Gladiator 6", "Adventure 5", "Torture 5", "Keeper 5", "Heart 8", "Extractor 8", "Gate 8", "Torture 6", "Goldpit 6", "Keeper 6", "Adventure 6",
                "Heart 9", "Extractor 9", "Gate 9", "Torture 7", "Goldpit 7", "Keeper 7", "Adventure 7", "Heart 10", "Extractor 10", "Gate 10"
                };

                foreach (var name in names2)
                {
                    conn.Execute("INSERT INTO UndergroundUpgrades (Name, IsChecked) VALUES (@Name, 0)", new { Name = name });
                }
            }



            var countDate = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM LastSacrificeDate");
            if (countDate == 0)
            {
                conn.Execute("INSERT INTO LastSacrificeDate (LastSacrifice) VALUES (NULL)");
            }

            ///////////////////// Parameters

            var countParam = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM AppConfiguration");
            if (countParam == 0)
            {
                conn.Execute("INSERT INTO AppConfiguration (ParamName, FlgStatus) VALUES ('TwitchDropNotification', 1)");
            }

        }

        public bool IsTwitchNotificationEnabled()
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.ExecuteScalar<int>(
                "SELECT FlgStatus FROM AppConfiguration WHERE ParamName = 'TwitchDropNotification' LIMIT 1"
            ) == 1;
        }

        public void UpdateTwitchNotification(int id, int FlgStatus)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute("UPDATE AppConfiguration SET FlgStatus = @FlgStatus WHERE Id = @id", new { id, FlgStatus });

        }


        public IEnumerable<ArenaUpgradeModel> GetAllArena()
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.Query<ArenaUpgradeModel>("SELECT * FROM ArenaUpgrades");
        }

        public void UpdateCheckedArena(int id, bool isChecked)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute("UPDATE ArenaUpgrades SET IsChecked = @isChecked WHERE Id = @id", new { id, isChecked });
        }

        public IEnumerable<ArenaUpgradeModel> GetAllUnderground()
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.Query<ArenaUpgradeModel>("SELECT * FROM UndergroundUpgrades");
        }

        public void UpdateCheckedUnderground(int id, bool isChecked)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute("UPDATE UndergroundUpgrades SET IsChecked = @isChecked WHERE Id = @id", new { id, isChecked });
        }

        public void UpdateLastSacrificeDate()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute("UPDATE LastSacrificeDate SET LastSacrifice = @now WHERE Id = 1", new { now = DateTime.Now });
        }

        public IEnumerable<LastSacrificeDateModel> SelectLastSacrificeDate()
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.Query<LastSacrificeDateModel>("SELECT LastSacrifice FROM LastSacrificeDate ORDER BY LastSacrifice DESC LIMIT 1");
        }

        public bool IsDropDone(DateTime dropDate)
        {
            using var conn = new SQLiteConnection(_connectionString);
            return conn.ExecuteScalar<int>(
                "SELECT IsDone FROM TwitchDropStatus WHERE DropDate = @DropDate",
                new { DropDate = dropDate.ToString("yyyy-MM-dd HH:mm") }
            ) == 1;
        }

        public void MarkDropAsDone(DateTime dropDate)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Execute(@"
            INSERT INTO TwitchDropStatus (DropDate, IsDone)
            VALUES (@DropDate, 1)
            ON CONFLICT(DropDate) DO UPDATE SET IsDone = 1",
                    new { DropDate = dropDate.ToString("yyyy-MM-dd HH:mm") });
        }

        public void EnsureDropExists(DateTime dropDate)
        {
            using var conn = new SQLiteConnection(_connectionString);
            var count = conn.ExecuteScalar<int>(
                "SELECT COUNT(*) FROM TwitchDropStatus WHERE DropDate = @DropDate",
                new { DropDate = dropDate.ToString("yyyy-MM-dd HH:mm") }
            );

            if (count == 0)
            {
                conn.Execute(
                    "INSERT INTO TwitchDropStatus (DropDate, IsDone) VALUES (@DropDate, 0)",
                    new { DropDate = dropDate.ToString("yyyy-MM-dd HH:mm") }
                );
            }
        }

        public void ResetCurrentWeekDrops()
        {
            var currentWeekDrops = new List<DateTime>
            {
                GetNextWeekday(DayOfWeek.Monday),
                GetNextWeekday(DayOfWeek.Wednesday),
                GetNextWeekday(DayOfWeek.Friday)
            };

            using var conn = new SQLiteConnection(_connectionString);
            foreach (var dropDate in currentWeekDrops)
            {
                conn.Execute("UPDATE TwitchDropStatus SET IsDone = 0 WHERE DropDate = @DropDate",
                    new { DropDate = dropDate.ToString("yyyy-MM-dd HH:mm") });
            }

            DateTime GetNextWeekday(DayOfWeek targetDat)
            {
                var today = DateTime.Today;
                int diff = (int)targetDat - (int)today.DayOfWeek;
                return today.AddDays(diff).AddHours(16);
            }
        }
    }
}
