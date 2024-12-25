using System.Collections.Generic;
using System.Threading.Tasks; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Media; 
using System.Windows.Shapes; 
using Xunit;
using StreetRacing.VisualElements; 

namespace Test.StreetRacing.VisualElements
{
    /// <summary>
    /// Class for testing WpfElements  
    /// </summary>
    public class WpfElementsTest
    {
        [Fact]
        public async Task CreateTextBlockOnCanvas_PassParameters_ParametersAreTheSame()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given 
                string text = "Text of test TextBlock"; 
                System.Windows.Media.Brush foregroundColor = System.Windows.Media.Brushes.Black; 
                double x = 20; 
                double y = 40; 
                double width = 50; 
                double height = 25; 
                double fontSize = 15; 
                
                //When
                TextBlock textBlock = WpfElements.CreateTextBlockOnCanvas(text, foregroundColor, x, y, width, height, fontSize); 
                
                //Then
                Assert.Equal(text, textBlock.Text); 
                Assert.Equal(foregroundColor, textBlock.Foreground); 
                Assert.Equal(x, Canvas.GetLeft(textBlock)); 
                Assert.Equal(y, Canvas.GetTop(textBlock)); 
                Assert.Equal(width, textBlock.Width); 
                Assert.Equal(height, textBlock.Height); 
                Assert.Equal(fontSize, textBlock.FontSize); 
            }); 
        }

        [Fact]
        public async Task DrawEllipseOnCanvas_PassParameters_ParametersAreTheSame()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double width = 50; 
                double height = 25;  
                double strokeThickness = 2; 
                System.Windows.Media.Brush strokeColor = System.Windows.Media.Brushes.Red;  
                System.Windows.Media.Brush fillColor = System.Windows.Media.Brushes.Blue; 
                double canvasTop = 150;  
                double canvasLeft = 250; 
                string name = "TestEllipse"; 
                
                //When
                Ellipse ellipse = WpfElements.DrawEllipseOnCanvas(width, height, strokeThickness, strokeColor, 
                    fillColor, canvasTop, canvasLeft, name); 
                
                //Then
                Assert.Equal(width, ellipse.Width); 
                Assert.Equal(height, ellipse.Height); 
                Assert.Equal(strokeThickness, ellipse.StrokeThickness); 
                Assert.Equal(strokeColor, ellipse.Stroke); 
                Assert.Equal(fillColor, ellipse.Fill); 
                Assert.Equal(canvasTop, Canvas.GetTop(ellipse)); 
                Assert.Equal(canvasLeft, Canvas.GetLeft(ellipse)); 
                Assert.Equal(name, ellipse.Name); 
            }); 
        }

        [Fact]
        public async Task DrawRectangleOnCanvas_PassParameters_ParametersAreTheSame()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double x = 500; 
                double y = 350;  
                double width = 150; 
                double height = 150; 
                System.Windows.Media.Brush strokeColor = System.Windows.Media.Brushes.Black;  
                System.Windows.Media.Brush fillColor = System.Windows.Media.Brushes.Green; 
                
                //When
                Rectangle rectangle = WpfElements.DrawRectangleOnCanvas(x, y, width, height, strokeColor, fillColor); 
                
                //Then
                Assert.Equal(x, Canvas.GetLeft(rectangle)); 
                Assert.Equal(y, Canvas.GetTop(rectangle)); 
                Assert.Equal(width, rectangle.Width); 
                Assert.Equal(height, rectangle.Height); 
                Assert.Equal(strokeColor, rectangle.Stroke); 
                Assert.Equal(fillColor, rectangle.Fill); 
            }); 
        }

        [Fact]
        public async Task FillColorBetweenPoints_PassParameters_ParametersAreTheSame()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                Path myPath = new Path(); 
                Canvas canvas = new Canvas(); 
                List<Point> points = new List<Point>() 
                {
                    new Point(34, 50), 
                    new Point(72, 23), 
                    new Point(30, 35) 
                }; 
                System.Windows.Media.Brush fillColor = System.Windows.Media.Brushes.Green; 
                
                //When
                WpfElements.FillColorBetweenPoints(myPath, canvas, points, fillColor); 
                
                //Then
                Assert.Equal(fillColor, myPath.Fill); 
            }); 
        }
    }
}