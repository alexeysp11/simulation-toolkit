using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace CarWPF
{
    /// <summary>
    /// Stores a path and all required requests to database. 
    /// </summary>
    public static class RequestsToDb
    {
        public static string path = "./DB/DB.sqlite3";
        public static string getRoad { get { return "SELECT * FROM Road"; } } 
    }

    /// <summary>
    /// Makes request in order to draw visual elements and define possible 
    /// trajectories. 
    /// </summary>
    public class VisualsDB
    {
        /// <summary>
        /// Makes request to DB in order to get definition of a road. 
        /// </summary>
        /// <param name="pathToDb">
        /// Relative path to production database. 
        /// </param>
        /// <param>
        /// Get request to database. 
        /// </param>
        /// <exception cref="System.Exception">
        /// Thrown when it is unable to create connection or make a request 
        /// to database. 
        /// </exception>
        /// <returns>Definition of a road, i.e. a list of road elements.</returns>
        public static List<RoadElement> GetRoad(string pathToDb, string request)
        {
            // Define variable road as a list of road elements. 
            List<RoadElement> road = new List<RoadElement>();
            
            // Create connection. 
            var connectionStringBuilder = new SqliteConnectionStringBuilder(); 
            connectionStringBuilder.DataSource = pathToDb;

            // Open connnection and execute SQL commands. 
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open(); 

                    // Read the records. 
                    var selectCmd = connection.CreateCommand(); 
                    selectCmd.CommandText = request;

                    // Iterate through the result. 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        // Add each instance of RoadElement class to the list of
                        // road elements. 
                        while (reader.Read())
                        {
                            // Create an object of `RoadElement` class. 
                            RoadElement roadelement = new RoadElement(); 

                            // Set properties of an object. 
                            roadelement.Id = reader.GetInt32(0);
                            roadelement.Page = reader.GetInt32(1);
                            roadelement.Name = reader.GetString(2);
                            roadelement.X1 = reader.GetInt32(3);
                            roadelement.X2 = reader.GetInt32(4);
                            roadelement.Y1 = reader.GetInt32(5);
                            roadelement.Y2 = reader.GetInt32(6);

                            // Add an object to the list. 
                            road.Add(roadelement);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show($"Failed to get a road from database:\n{e}"); 
                }
            }
            
            // Return variable road as a list of road elements. 
            return road;
        }

        /// <summary>
        /// Makes request in order to initialize edges. 
        /// </summary>
        public static void GetEdges()
        {

        }

        /// <summary>
        /// Makes request in order to initialize vertices. 
        /// </summary>
        public static void GetVertices()
        {

        }
    }
}