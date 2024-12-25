using System.Collections.Generic;
using Xunit;
using CarWPF;

namespace Test.CarWPF.TestDB
{
    /// <summary>
    /// Tests `CarWPF.VisualsDB` class. 
    /// </summary>
    public class VisualsDBTests
    {
        /// <summary>
        /// Relative path from `MockDatabaseController` to testing database. 
        /// </summary>
        private const string RelPathFromDbCntrlToTestDb = "../../../DB/TestVisualsDB.db";

        [Fact]
        public void GetRoad_SimpleRequestToDb_ReturnsCorrectListOfRoadElement()
        {
            // Create database controller. 
            var DbController = new MockDatabaseController(
                RelPathFromDbCntrlToTestDb
            );

            // Create database and insert data. 
            DbController.CreateDbAndInsertData(
                TestDbRequests.CreateRequest, 
                TestDbRequests.InsertRequest
            );

            // Make request to DB to get a list of road elements. 
            List<RoadElement> road = VisualsDB.GetRoad(
                RelPathFromDbCntrlToTestDb, 
                RequestsToDb.getRoad
            );

            Assert.Equal(road[0].Page, TestDbRoadElement.Page); 
            Assert.Equal(road[0].Name, TestDbRoadElement.Name); 
            Assert.Equal(road[0].X1, TestDbRoadElement.X1); 
            Assert.Equal(road[0].X2, TestDbRoadElement.X2); 
            Assert.Equal(road[0].Y1, TestDbRoadElement.Y1); 
            Assert.Equal(road[0].Y2, TestDbRoadElement.Y2); 
        }

        [Fact]
        public void GetEdges_SimpleRequestToDb_ReturnsCorrectListOfRoadElement()
        {
            
        }

        [Fact]
        public void GetVertices_SimpleRequestToDb_ReturnsCorrectListOfRoadElement()
        {
            
        }
    }
}
