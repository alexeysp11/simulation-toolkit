using System;
using System.Windows; 
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media; 
using System.Windows.Shapes; 
using StreetRacing.Commands;
using StreetRacing.View;
using StreetRacing.Exceptions;
using StreetRacing.VisualElements;

namespace StreetRacing.ViewModel
{
    /// <summary>
    /// Calss that allows to use speedometer 
    /// </ssummary>
    public class SpeedometerVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Commands
        /// <summary>
        /// Command that is used to regulate speed 
        /// </summary>
        public ICommand RegulateSpeedCommand { get; private set; }
        #endregion  // Commands

        #region Properties
        /// <summary>
        /// Current angle of rotation 
        /// </summary>
        public double Angle 
        { 
            get { return SpeedKmPerHour - StepSpeed; }
        }
        /// <summary>
        /// Step between point with labels on the speedometer 
        /// </summary>
        private double StepSpeed = 20; 
        /// <summary>
        /// Minimal available speed that speedometer can measure 
        /// </summary>
        private double MinSpeed = 0;
        /// <summary>
        /// Maximal available speed that speedometer can measure 
        /// </summary>
        private double MaxSpeed = 220;
        /// <summary>
        /// Current speed in km/h (for only storing variable) 
        /// </summary>
        private double speed = 0;
        /// <summary>
        /// Current speed in km/h (for use) 
        /// </summary>
        public double SpeedKmPerHour
        {
            get { return speed; }
            set 
            {
                if (value > MaxSpeed)
                {
                    speed = MaxSpeed; 
                }
                else if (value < MinSpeed)
                {
                    speed = MinSpeed; 
                }
                else
                {
                    speed = value; 
                }
            }
        }
        #endregion  // Properties

        #region Constructor
        /// <summary>
        /// Constructor of SpeedometerVM
        /// </summary>
        /// <param name="window">Instance of MainWindow</param>
        public SpeedometerVM(MainWindow window)
        {
            // Command to regulate speed on speedometer 
            this.RegulateSpeedCommand = new RegulateSpeedCommand(this); 

            // MainWindow instance to acces all elements on the canvas
            this._MainWindow = window;
            
            // Initial speed equal to zero
            this.SpeedKmPerHour = 0; 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to draw all visual elements of speedometer
        /// </summary>
        public void DrawVisualElementsOfSpeedometer()
        {
            try
            {
                this.DrawSpeedometerArrow(); 
                this.RotateSpeedometerArrow(); 
                this.DrawSpeedometerArc(); 
                this.AddLabelsToSpeedometerArc(); 
            }
            catch (System.Exception ex)
            {
                ExceptionViewer.WatchExceptionMessageBox(ex); 
            }
        }

        /// <summary>
        /// Allows to draw speedometer arrow relative to the screen size 
        /// </summary>
        private void DrawSpeedometerArrow()
        {
            this._MainWindow.SpeedometerArrow.X1 = 0.277 * this._MainWindow.MainCanvas.ActualWidth; 
            this._MainWindow.SpeedometerArrow.X2 = this._MainWindow.SpeedometerArrow.X1 - this._MainWindow.MainCanvas.ActualWidth / 20; 
            this._MainWindow.SpeedometerArrow.Y1 = 0.755 * this._MainWindow.MainCanvas.ActualHeight; 
            this._MainWindow.SpeedometerArrow.Y2 = this._MainWindow.SpeedometerArrow.Y1; 
            Canvas.SetZIndex(this._MainWindow.SpeedometerArrow, 2);
        }

        /// <summary>
        /// Allows to rotate speedometer arrow and point on current speed 
        /// </summary>
        /// <param name="deltaSpeed">Change of speed</param>
        public void RotateSpeedometerArrow(double deltaSpeed=0)
        {
            try
            {
                // Redefine speed 
                this.SpeedKmPerHour += deltaSpeed; 

                // Assign line that needs to be rotated
                Line speedometerArrow = this._MainWindow.SpeedometerArrow; 

                // Rotate a line using RotateTransform
                RotateTransform rotateTransform = new RotateTransform();
                rotateTransform.CenterX = speedometerArrow.X1;
                rotateTransform.CenterY = speedometerArrow.Y1;
                rotateTransform.Angle = this.Angle; 
                this._MainWindow.SpeedometerArrow.RenderTransform = rotateTransform;
            }
            catch (System.Exception e)
            {
                ExceptionViewer.WatchExceptionMessageBox(e); 
            }
        }

        /// <summary>
        /// Allows to draw speedometer arc  
        /// </summary>
        private void DrawSpeedometerArc()
        {
            // Set Z-index to avoid hiding speedometer arc by other elements and filling
            Canvas.SetZIndex(this._MainWindow.SpeedometerArrow, 2); 
            Canvas.SetZIndex(this._MainWindow.SpeedometerArc, 2); 
            
            // Define coordinates of a line for convinience 
            double X1 = this._MainWindow.SpeedometerArrow.X1; 
            double X2 = this._MainWindow.SpeedometerArrow.X2; 
            double Y1 = this._MainWindow.SpeedometerArrow.Y1; 
            double Y2 = this._MainWindow.SpeedometerArrow.Y2; 
            
            try
            {
                // Assign coordinates of a start point
                double r = System.Math.Sqrt(System.Math.Pow((X2 - X1), 2) + System.Math.Pow((Y2 - Y1), 2)); 
                double radians = (this.MinSpeed - this.StepSpeed) * System.Math.PI / 180; 
                double x = X1 - r * System.Math.Cos(radians); 
                double y = Y1 - r * System.Math.Sin(radians); 
                
                // Correct arc for speedometer 
                PathFigure myPathFigure = new PathFigure();
                myPathFigure.StartPoint = new Point(x, y);

                // Assign coordinates of an end point
                radians = (this.MaxSpeed - this.StepSpeed) * System.Math.PI / 180; 
                x = X1 - r * System.Math.Cos(radians); 
                y = Y1 - r * System.Math.Sin(radians);

                // Add ArcSegment
                Size desiredSize = new Size(r, r);
                ArcSegment arc = new ArcSegment(new Point(x, y), desiredSize, 0, true, SweepDirection.Clockwise, true);
                
                // Add ArcSegment to PathFigure
                myPathFigure.Segments.Add(arc);

                // Define PathGeometry
                PathGeometry myPathGeometry = new PathGeometry();
                myPathGeometry.Figures.Add(myPathFigure);

                // Correct Path
                this._MainWindow.SpeedometerArc.Stroke = Brushes.Black;
                this._MainWindow.SpeedometerArc.StrokeThickness = 1;
                this._MainWindow.SpeedometerArc.Data = myPathGeometry;
            }
            catch (System.Exception e)
            {
                ExceptionViewer.WatchExceptionMessageBox(e); 
            }
        }

        /// <summary>
        /// Allows to add labels to speedometer arc  
        /// </summary>
        private void AddLabelsToSpeedometerArc()
        {
            // Define coordinates of a line for convinience 
            double X1 = this._MainWindow.SpeedometerArrow.X1; 
            double X2 = this._MainWindow.SpeedometerArrow.X2; 
            double Y1 = this._MainWindow.SpeedometerArrow.Y1; 
            double Y2 = this._MainWindow.SpeedometerArrow.Y2; 

            // Assign start point
            double r = System.Math.Sqrt(System.Math.Pow((X2 - X1), 2) + System.Math.Pow((Y2 - Y1), 2)); 
            double radians = 0; 
            
            // Declare coordinates for points and labels
            double x1 = 0; 
            double y1 = 0; 
            double x2 = 0; 
            double y2 = 0; 
            double xLabel = 0; 
            double yLabel = 0; 

            // Add points to the canvas
            this.SpeedKmPerHour = 0; 
            double divisions = (MaxSpeed - MinSpeed) / StepSpeed; 
            for (int i = 0; i <= divisions; i++)
            {
                // Increase speed to set a label 
                SpeedKmPerHour = i * StepSpeed; 

                // Define X and Y coordinates for a point 
                radians = Angle * System.Math.PI / 180; 
                x1 = X1 - r * System.Math.Cos(radians); 
                y1 = Y1 - r * System.Math.Sin(radians); 
                x2 = X1 - (r * 0.9) * System.Math.Cos(radians); 
                y2 = Y1 - (r * 0.9) * System.Math.Sin(radians); 
                
                // X and Y coordinates for labels
                xLabel = X1 - (r * 1.2) * System.Math.Cos(radians); 
                yLabel = Y1 - (r * 1.2) * System.Math.Sin(radians); 
                
                // Add new point to the canvas 
                Line myLine = WpfElements.CreateLine(x1, x2, y1, y2, System.Windows.Media.Brushes.Black, 1); 
                Canvas.SetZIndex(myLine, 2); 
                this._MainWindow.MainCanvas.Children.Add(myLine); 

                // Add labels
                double width = 20; 
                double height = 10; 
                double x = xLabel - width/4; 
                double y = yLabel - height/2; 
                double fontSize = 8; 
                TextBlock textBlock = WpfElements.CreateTextBlockOnCanvas(
                    $"{SpeedKmPerHour}", System.Windows.Media.Brushes.Black, 
                    x, y, width, height, fontSize); 
                Canvas.SetZIndex(textBlock, 2); 
                this._MainWindow.MainCanvas.Children.Add(textBlock);
            }

            // Set speed to zero 
            this.SpeedKmPerHour = 0; 
        }
        #endregion  // Methods
    }
}