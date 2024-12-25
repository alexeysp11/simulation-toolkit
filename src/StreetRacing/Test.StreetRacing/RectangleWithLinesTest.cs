using System;
using System.Threading.Tasks; 
using Xunit;
using StreetRacing.VisualElements;

namespace Test.StreetRacing.VisualElements
{
    /// <summary>
    /// Class for testing RectangleWithLines
    /// </summary>
    public class RectangleWithLinesTest
    {
        [Fact]
        public async Task PlaceToInitialPoints_CallingMethod_CheckIfPointsEqualToInitial()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double width = 250; 
                double height = 150; 
                double xLeftTop = 100; 
                double yLeftTop = 50; 
                
                RectangleWithLines rect = new RectangleWithLines(width, height, 
                    xLeftTop, yLeftTop, System.Windows.Media.Brushes.Black, 1); 
                
                double x1 = rect.X1; 
                double y1 = rect.Y1; 
                double x3 = rect.X3; 
                double x4 = rect.X4; 
            
                //When
                rect.X1 += 150; 
                rect.Y1 -= 407; 
                rect.X3 += 500; 
                rect.X4 -= 23; 

                rect.PlaceToInitialPoints(); 
                
                //Then
                Assert.Equal(rect.X1, x1); 
                Assert.Equal(rect.Y1, y1); 
                Assert.Equal(rect.X3, x3); 
                Assert.Equal(rect.X4, x4); 
            });
        }
    }
}
