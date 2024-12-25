using System.Threading.Tasks; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Shapes; 
using Xunit;
using StreetRacing.VisualElements; 

namespace Test.StreetRacing.VisualElements
{
    /// <summary>
    /// Class for testing WpfGeometry 
    /// </summary>
    public class WpfGeometryTest
    {
        #region Rotation of a point 
        [Fact]
        public async Task RotatePointRotationMatrix_ZeroDeg_SamePointOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = xPoint; 
                double yPointAfterRotation = yPoint; 
                double radians = WpfGeometry.DegreesToRadians(0); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 

                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointRotationMatrix_Positive90Deg_PointIn90DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                double radians = WpfGeometry.DegreesToRadians(90); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 

                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }
        
        [Fact]
        public async Task RotatePointRotationMatrix_Negative90Deg_PointIn270DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = -1.0; 
                double radians = WpfGeometry.DegreesToRadians(-90); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointRotationMatrix_Positive180Deg_PointIn180DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = -1.0; 
                double yPointAfterRotation = 0.0; 
                double radians = WpfGeometry.DegreesToRadians(180); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointRotationMatrix_Negative180Deg_PointIn180DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = -1.0; 
                double yPointAfterRotation = 0.0; 
                double radians = WpfGeometry.DegreesToRadians(-180); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointDistanceToCenter_ZeroDeg_SamePointOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0;  
                double radians = WpfGeometry.DegreesToRadians(0);
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = xPoint; 
                double yPointAfterRotation = yPoint; 
                
                //When
                WpfGeometry.RotatePoint(distance, radians, out xPoint, out yPoint); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointDistanceToCenter_Positive90Deg_PointIn90DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0;  
                double radians = WpfGeometry.DegreesToRadians(90);
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                
                //When
                WpfGeometry.RotatePoint(distance, radians, out xPoint, out yPoint); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }
        
        [Fact]
        public async Task RotatePointDistanceToCenter_Negative90Deg_PointIn270DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0;  
                double radians = WpfGeometry.DegreesToRadians(90);
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                
                //When
                WpfGeometry.RotatePoint(distance, radians, out xPoint, out yPoint); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task GetAngleOnCircle_ZeroDeg_PointOnUnitCircleAtZeroDeg()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0; 
                double x = 1.0; 
                double y = 0.0; 
                double angleExpected = 0; 
                
                //When
                double radiansCalculated = WpfGeometry.GetAngleOnCircle(distance, x, y);
                double angleCalculated = WpfGeometry.RadiansToDegrees(radiansCalculated);  
                
                //Then
                Assert.Equal(angleExpected, angleCalculated, 5); 
            }); 
        }

        [Fact]
        public async Task GetAngleOnCircle_Positive90Deg()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0; 
                double x = 0.0; 
                double y = 1.0; 
                double angleExpected = 90; 
                
                //When
                double radiansCalculated = WpfGeometry.GetAngleOnCircle(distance, x, y);
                double angleCalculated = WpfGeometry.RadiansToDegrees(radiansCalculated);  
                
                //Then
                Assert.Equal(angleExpected, angleCalculated, 5); 
            }); 
        }
        #endregion  // Rotation of a point 

        #region Rotation of a line
        [Fact]
        public async Task RotateLine_Positive90Deg_RotationTroughPositive90Deg()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance1 = 1.0; 
                double distance2 = 1.0;  
                double radians1 = WpfGeometry.DegreesToRadians(90); 
                double radians2 = WpfGeometry.DegreesToRadians(180); 
                Line lineBeforeRotation = WpfElements.CreateLine(1.0, 0.0, 0.0, 1.0, null, 1, null); 
                double xCenter = 0.0; 
                double yCenter = 0.0; 
                
                //When
                Line lineAfterRotation = WpfGeometry.RotateLine(distance1, distance2, 
                    radians1, radians2, lineBeforeRotation, xCenter, yCenter); 
                
                //Then
                Assert.Equal(0.0, lineAfterRotation.X1, 5); 
                Assert.Equal(-1.0, lineAfterRotation.X2, 5); 
                Assert.Equal(1.0, lineAfterRotation.Y1, 5); 
                Assert.Equal(0.0, lineAfterRotation.Y2, 5); 
            });
        }

        [Fact]
        public async Task RotateLine_Negative90Deg_RotationTroughNegative90Deg()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance1 = 1.0; 
                double distance2 = 1.0;  
                double radians1 = WpfGeometry.DegreesToRadians(-90); 
                double radians2 = WpfGeometry.DegreesToRadians(0); 
                Line lineBeforeRotation = WpfElements.CreateLine(1.0, 0.0, 0.0, 1.0, null, 1, null); 
                double xCenter = 0.0; 
                double yCenter = 0.0; 
                
                //When
                Line lineAfterRotation = WpfGeometry.RotateLine(distance1, distance2, 
                    radians1, radians2, lineBeforeRotation, xCenter, yCenter); 
                
                //Then
                Assert.Equal(0.0, lineAfterRotation.X1, 5); 
                Assert.Equal(1.0, lineAfterRotation.X2, 5); 
                Assert.Equal(-1.0, lineAfterRotation.Y1, 5); 
                Assert.Equal(0.0, lineAfterRotation.Y2, 5); 
            });
        }
        #endregion  // Rotation of a line
    }
}