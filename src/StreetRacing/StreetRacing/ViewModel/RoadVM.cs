using System.Collections.Generic;
using System.Windows; 
using System.Windows.Shapes; 
using StreetRacing.View; 
using StreetRacing.VisualElements; 

namespace StreetRacing.ViewModel
{
    /// <summary>
    /// Class for drawing a road on the canvas  
    /// </summary>
    public class RoadVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Constructor
        /// <summary>
        /// Constructor of RoadVM
        /// </summary>
        /// <param name="window">Instance of MainWindow</param>
        public RoadVM(MainWindow window)
        {
            // MainWindow instance to acces all elements on the canvas
            _MainWindow = window; 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to draw road on the canvas
        /// </summary>
        public void DrawRoad()
        {
            // Determine width and height of a canvas
            double width = this._MainWindow.MainCanvas.ActualWidth; 
            double height = this._MainWindow.MainCanvas.ActualHeight; 
            
            // Create lines of a road
            Line line1 = WpfElements.CreateLine(0, 0.103*width, 0.375*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line1); 
            Line line2 = WpfElements.CreateLine(width - line1.X1, width - line1.X2, line1.Y1, line1.Y2, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line2); 
            Line line3 = WpfElements.CreateLine(0, 0.141*width, 0.492*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line3); 
            Line line4 = WpfElements.CreateLine(width - line3.X1, width - line3.X2, line3.Y1, line3.Y2, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line4); 
            Line line5 = WpfElements.CreateLine(0.307*width, 0.415*width, 0.5*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line5); 
            Line line6 = WpfElements.CreateLine(0.342*width, 0.449*width, 0.5*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line6); 

            // Fill a color for left side of a road (line3 and line5)
            List<Point> leftSideOfRoad = new List<Point>();
            Path leftSideOfRoadPath = new Path(); 
            leftSideOfRoad.Add(new Point(0, height)); 
            leftSideOfRoad.Add(new Point(line3.X1, line3.Y1)); 
            leftSideOfRoad.Add(new Point(line3.X2, line3.Y2)); 
            leftSideOfRoad.Add(new Point(line5.X2, line5.Y2)); 
            leftSideOfRoad.Add(new Point(line5.X1, line5.Y1)); 
            WpfElements.FillColorBetweenPoints(leftSideOfRoadPath, 
                this._MainWindow.MainCanvas, leftSideOfRoad, 
                System.Windows.Media.Brushes.LightGray); 
            
            // Fill a color for right side of a road (line4 and line6)
            List<Point> rightSideOfRoad = new List<Point>();
            Path rightSideOfRoadPath = new Path(); 
            rightSideOfRoad.Add(new Point(width, height)); 
            rightSideOfRoad.Add(new Point(line4.X1, line4.Y1)); 
            rightSideOfRoad.Add(new Point(line4.X2, line4.Y2)); 
            rightSideOfRoad.Add(new Point(line6.X2, line6.Y2)); 
            rightSideOfRoad.Add(new Point(line6.X1, line6.Y1)); 
            WpfElements.FillColorBetweenPoints(rightSideOfRoadPath, 
                this._MainWindow.MainCanvas, rightSideOfRoad, 
                System.Windows.Media.Brushes.LightGray); 
            
            // Fill a color for center line of a road (line5 and line6)
            List<Point> centerLine = new List<Point>();
            Path centerLinePath = new Path(); 
            centerLine.Add(new Point(line5.X1, line5.Y1)); 
            centerLine.Add(new Point(line5.X2, line5.Y2)); 
            centerLine.Add(new Point(line6.X2, line6.Y2)); 
            centerLine.Add(new Point(line6.X1, line6.Y1)); 
            WpfElements.FillColorBetweenPoints(centerLinePath, 
                this._MainWindow.MainCanvas, centerLine, 
                System.Windows.Media.Brushes.Yellow); 
            
            // Fill a color for left pavement (line1 and line3)
            List<Point> leftPavement = new List<Point>();
            Path leftPavementPath = new Path(); 
            leftPavement.Add(new Point(line1.X1, line1.Y1)); 
            leftPavement.Add(new Point(line1.X2, line1.Y2)); 
            leftPavement.Add(new Point(line3.X2, line3.Y2)); 
            leftPavement.Add(new Point(line3.X1, line3.Y1)); 
            WpfElements.FillColorBetweenPoints(leftPavementPath, 
                this._MainWindow.MainCanvas, leftPavement, 
                System.Windows.Media.Brushes.LightBlue); 
            
            // Fill a color for right pavement (line2 and line4)
            List<Point> rightPavement = new List<Point>();
            Path rightPavementPath = new Path(); 
            rightPavement.Add(new Point(line2.X1, line2.Y1)); 
            rightPavement.Add(new Point(line2.X2, line2.Y2)); 
            rightPavement.Add(new Point(line4.X2, line4.Y2)); 
            rightPavement.Add(new Point(line4.X1, line4.Y1)); 
            WpfElements.FillColorBetweenPoints(rightPavementPath, 
                this._MainWindow.MainCanvas, rightPavement, 
                System.Windows.Media.Brushes.LightBlue); 
            
            // Fill a color for left verge (line1)
            List<Point> leftVerge = new List<Point>();
            Path leftVergePath = new Path(); 
            leftVerge.Add(new Point(0, 0)); 
            leftVerge.Add(new Point(line1.X1, line1.Y1)); 
            leftVerge.Add(new Point(line1.X2, line1.Y2)); 
            WpfElements.FillColorBetweenPoints(leftVergePath, 
                this._MainWindow.MainCanvas, leftVerge, 
                System.Windows.Media.Brushes.LightGreen); 
            
            // Fill a color for rigth verge (line2)
            List<Point> rigthVerge = new List<Point>();
            Path rigthVergePath = new Path(); 
            rigthVerge.Add(new Point(width, 0)); 
            rigthVerge.Add(new Point(line2.X1, line2.Y1)); 
            rigthVerge.Add(new Point(line2.X2, line2.Y2)); 
            WpfElements.FillColorBetweenPoints(rigthVergePath, 
                this._MainWindow.MainCanvas, rigthVerge, 
                System.Windows.Media.Brushes.LightGreen); 
        }
        #endregion  // Methods
    }
}