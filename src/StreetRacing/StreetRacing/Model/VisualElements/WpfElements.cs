using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Media; 
using System.Windows.Shapes; 

namespace StreetRacing.VisualElements
{
    /// <summary>
    /// Allows to create different visual elements 
    /// </summary>
    public static class WpfElements
    {
        /// <summary>
        /// Allows to create TextBlock on Canvas
        /// </summary>
        /// <param name="text">Text into TextBlock</param>
        /// <param name="foregroundColor">Color of a text</param>
        /// <param name="x">X coordinate of left top angle</param>
        /// <param name="y">Y coordinate of left top angle</param>
        /// <param name="width">Width of TextBlock</param>
        /// <param name="height">Height of TextBlock</param>
        /// <param name="fontSize">Size of text</param>
        /// <returns>Instance of TextBlock</returns>
        public static TextBlock CreateTextBlockOnCanvas(string text, 
            System.Windows.Media.Brush foregroundColor, double x, double y, 
            double width, double height, double fontSize)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = foregroundColor;
            textBlock.Width = width; 
            textBlock.Height = height; 
            textBlock.FontSize = fontSize; 
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            return textBlock; 
        }

        /// <summary>
        /// Allows to create Line 
        /// </summary>
        /// <param name="x1">X coordinate of point 1</param>
        /// <param name="x2">X coordinate of point 2</param>
        /// <param name="y1">Y coordinate of point 1</param>
        /// <param name="y2">Y coordinate of point 2</param>
        /// <param name="strokeColor">Color of stroke</param>
        /// <param name="strokeThickness">Thickness of stroke</param>
        /// <returns>Instance of Line</returns>
        public static Line CreateLine(double x1, double x2, double y1, double y2, 
            System.Windows.Media.Brush strokeColor, double strokeThickness, 
            string name=null)
        {
            Line myLine = new Line();
            myLine.Stroke = strokeColor;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.StrokeThickness = strokeThickness;
            myLine.Name = name; 
            return myLine; 
        }

        /// <summary>
        /// Allows to draw ellipse on the canvas 
        /// </summary>
        /// <param name="width">Width of Ellipse</param>
        /// <param name="height">Height of Ellipse</param>
        /// <param name="strokeThickness">Thickness of stroke</param>
        /// <param name="strokeColor">Color of stroke</param>
        /// <param name="fillColor">Color of fill</param>
        /// <param name="canvasTop">Y coordinate of top left angle onto canvas</param>
        /// <param name="canvasLeft">X coordinate of top left angle onto canvas</param>
        /// <param name="name">Name of Ellipse (used for proving access to the ellipse in code)</param>
        /// <returns>Instance of Ellipse</returns>
        public static Ellipse DrawEllipseOnCanvas(double width, double height, 
            double strokeThickness, System.Windows.Media.Brush strokeColor, 
            System.Windows.Media.Brush fillColor, double canvasTop, 
            double canvasLeft, string name)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Name = name; 
            myEllipse.Stroke = strokeColor;
            myEllipse.StrokeThickness = strokeThickness;
            myEllipse.Fill = fillColor;
            myEllipse.Width = width;
            myEllipse.Height = height;
            Canvas.SetTop(myEllipse, canvasTop); 
            Canvas.SetLeft(myEllipse, canvasLeft); 
            return myEllipse; 
        }

        /// <summary>
        /// Allows to create Rectangle 
        /// </summary>
        /// <param name="x">X coordinate of top left angle onto canvas</param>
        /// <param name="y">Y coordinate of top left angle onto canvas</param>
        /// <param name="width">Width of Rectangle</param>
        /// <param name="height">Height of Rectangle</param>
        /// <param name="strokeColor">Color of stroke</param>
        /// <param name="fillColor">Color of fill</param>
        /// <returns>Instance of Rectangle</returns>
        public static Rectangle DrawRectangleOnCanvas(double x, double y, 
            double width, double height, System.Windows.Media.Brush strokeColor, 
            System.Windows.Media.Brush fillColor)
        {
            var myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = strokeColor;
            myRect.Fill = fillColor;
            myRect.Height = height;
            myRect.Width = width;
            Canvas.SetLeft(myRect, x); 
            Canvas.SetTop(myRect, y); 
            return myRect; 
        }

        #region Filling a color
        /// <summary>
        /// Allows to fill a color at runtime using Path and adds Path on the canvas 
        /// </summary>
        /// <param name="myPath">Closed path</param>
        /// <param name="canvas">Instance of Canvas</param>
        /// <param name="points">List of points of a path</param>
        /// <param name="fillColor">Color of filling</param>
        public static void FillColorBetweenPoints(Path myPath, Canvas canvas, List<Point> points, System.Windows.Media.Brush fillColor)
        {
            // Create Path
            myPath.Fill = fillColor;
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.StrokeThickness = 1;
            Canvas.SetZIndex(myPath, 1); 

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(points[0].X, points[0].Y);

            for (int i = 1; i < points.Count; i++)
            {
                LineSegment lineSegment = new LineSegment();
                lineSegment.Point = new Point(points[i].X, points[i].Y);
                pathFigure.Segments.Add(lineSegment);
            }

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = new PathFigureCollection();

            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);

            myPath.Data = pathGeometry;
            
            canvas.Children.Add(myPath); 
        }
        #endregion  // Filling a color
    }
}