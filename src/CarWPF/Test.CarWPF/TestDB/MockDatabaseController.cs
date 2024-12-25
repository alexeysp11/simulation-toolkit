using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Test.CarWPF.TestDB
{
    /// <summary>
    /// Stores data for testing `CarWPF.VisualsBD` using `CarWPF.RoadElement`
    /// and imitates `CarWPF.RoadElement` class. 
    /// </summary>
    public static class TestDbRoadElement
    {
        public static int Id = 1; 
        public static int Page = 1; 
        public static string Name = "Border"; 
        public static int X1 = 1; 
        public static int X2 = 360; 
        public static int Y1 = 1; 
        public static int Y2 = 360; 
    }

    /// <summary>
    /// Stores requests for testing `CarWPF.VisualsBD`.
    /// </summary>
    class TestDbRequests
    {
        public static string CreateRequest = @"CREATE TABLE IF NOT EXISTS Road(
            Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
            Page INTEGER, 
            Name TEXT, 
            X1 INTEGER, 
            X2 INTEGER, 
            Y1 INTEGER, 
            Y2 INTEGER
            );"; 

        public static string InsertRequest = 
        $@"INSERT INTO Road (Page, Name, X1, X2, Y1, Y2) 
            VALUES({TestDbRoadElement.Page}, 
                '{TestDbRoadElement.Name}', 
                {TestDbRoadElement.X1}, 
                {TestDbRoadElement.X2}, 
                {TestDbRoadElement.Y1}, 
                {TestDbRoadElement.Y2});"; 
    }

    /// <summary>
    /// Provides functionality for testing databases in this app.
    /// </summary>
    public class MockDatabaseController
    {
        /// <summary>
        /// Relative path from this class to testing database. 
        /// </summary>
        public string _relPathToDb { get; private set; } 

        /// <summary>
        /// Constructor of class `MockDatabaseController`. 
        /// </summary>
        public MockDatabaseController(string relPathToDb)
        {
            _relPathToDb = relPathToDb; 
        }

        /// <summary>
        /// Creates a database and inserts data into it. 
        /// </summary>
        /// <remarks>
        /// Creates a database if and only if it does not exist yet.
        /// </remarks>
        public void CreateDbAndInsertData(string createRequest, string insertRequest)
        {
            // Create connection. 
            var connectionStringBuilder = new SqliteConnectionStringBuilder(); 
            connectionStringBuilder.DataSource = this._relPathToDb;
            
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    // Open connection. 
                    connection.Open(); 

                    /* Create a table only if `TestVisualsDB.db` exists.
                    Remarks: this if statement is not working, check if a 
                    file alreday exists using SQL statement IF NOT EXISTS */
                    if (System.IO.File.Exists(connectionStringBuilder.DataSource)) 
                    {
                        var tableCmd = connection.CreateCommand(); 
                        tableCmd.CommandText = createRequest; 
                        tableCmd.ExecuteNonQuery(); 
                    }
                    
                    // Insert some records. 
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insertCmd = connection.CreateCommand(); 
                        insertCmd.CommandText = insertRequest;      // SQL command. 
                        insertCmd.ExecuteNonQuery();                // Execute SQL command. 
                        transaction.Commit();                       // Commit changes. 
                    }
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show($"Failed to get a road from test database:\n{e}"); 
                }
            }
        }
    }
}