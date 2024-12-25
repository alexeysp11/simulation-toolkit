using System.Windows.Shapes; 

namespace StreetRacing.VisualElements
{
    /// <summary>
    /// Class that helps to draw rectangle as 4 lines
    /// </summary>
    public class RectangleWithLines
    {
        #region Initial coordinates
        /// <summary>
        /// Initial coordinate of X1 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX1 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of X2 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX2 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of X3 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX3 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of X4 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX4 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of Y1 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY1 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of Y2 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY2 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of Y3 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY3 { get; private set; } = 0; 
        /// <summary>
        /// Initial coordinate of Y4 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY4 { get; private set; } = 0; 
        #endregion  // Initial coordinates

        #region X coordinates
        /// <summary>
        /// X-coordinate of point 1
        /// </summary>
        public double X1 
        { 
            set 
            {
                Line1.X1 = value; 
                Line4.X2 = Line1.X1; 
            }
            get { return Line1.X1; }
        }
        /// <summary>
        /// X-coordinate of point 2
        /// </summary>
        public double X2 
        {
            set
            {
                Line1.X2 = value; 
                Line2.X1 = Line1.X2; 
            }
            get { return Line2.X1; }
        }
        /// <summary>
        /// X-coordinate of point 3
        /// </summary>
        public double X3 
        {
            set
            {
                Line2.X2 = value; 
                Line3.X1 = Line2.X2; 
            }
            get { return Line3.X1; }
        }
        /// <summary>
        /// X-coordinate of point 4
        /// </summary>
        public double X4 
        {
            set 
            {
                Line3.X2 = value; 
                Line4.X1 = Line3.X2; 
            }
            get { return Line4.X1; }
        }
        #endregion  // X coordinates

        #region Y coordinates
        /// <summary>
        /// Y-coordinate of point 1
        /// </summary>
        public double Y1 
        {
            set
            {
                Line1.Y1 = value; 
                Line4.Y2 = Line1.Y1; 
            }
            get { return Line1.Y1; }
        }
        /// <summary>
        /// Y-coordinate of point 2
        /// </summary>
        public double Y2 
        {
            set 
            {
                Line1.Y2 = value; 
                Line2.Y1 = Line1.Y2; 
            }
            get { return Line2.Y1; }
        }
        /// <summary>
        /// Y-coordinate of point 3
        /// </summary>
        public double Y3 
        {
            set  
            {
                Line2.Y2 = value; 
                Line3.Y1 = Line2.Y2; 
            }
            get { return Line3.Y1; }
        }
        /// <summary>
        /// Y-coordinate of point 4
        /// </summary>
        public double Y4 
        {
            set  
            {
                Line3.Y2 = value; 
                Line4.Y1 = Line3.Y2; 
            }
            get { return Line4.Y1; }
        }
        #endregion  // Y coordinates

        #region Lines
        /// <summary>
        /// Line 1 of rectangle (used only for drawing rectangle on the canvas)
        /// </summary>
        public Line Line1 { get; private set; } = new Line(); 
        /// <summary>
        /// Line 2 of rectangle (used only for drawing rectangle on the canvas)
        /// </summary>
        public Line Line2 { get; private set; } = new Line(); 
        /// <summary>
        /// Line 3 of rectangle (used only for drawing rectangle on the canvas)
        /// </summary>
        public Line Line3 { get; private set; } = new Line(); 
        /// <summary>
        /// Line 4 of rectangle (used only for drawing rectangle on the canvas)
        /// </summary>
        public Line Line4 { get; private set; } = new Line(); 
        #endregion  // Lines

        #region Constructor
        public RectangleWithLines(double width, double height, double x1, double y1, 
            System.Windows.Media.Brush color, double strokeThickness)
        {
            // Line1
            Line1.X1 = x1; 
            Line1.Y1 = y1; 
            Line1.X2 = Line1.X1 + width; 
            Line1.Y2 = Line1.Y1; 
            Line1.Stroke = color;
            Line1.StrokeThickness = strokeThickness;

            // Line2
            Line2.X1 = Line1.X2; 
            Line2.Y1 = Line1.Y2; 
            Line2.X2 = Line2.X1; 
            Line2.Y2 = Line1.Y2 + height; 
            Line2.Stroke = color;
            Line2.StrokeThickness = strokeThickness;

            // Line3
            Line3.X1 = Line2.X2; 
            Line3.Y1 = Line2.Y2; 
            Line3.X2 = Line3.X1 - width; 
            Line3.Y2 = Line2.Y2; 
            Line3.Stroke = color;
            Line3.StrokeThickness = strokeThickness;

            // Line4
            Line4.X1 = Line3.X2; 
            Line4.Y1 = Line3.Y2; 
            Line4.X2 = Line4.X1; 
            Line4.Y2 = Line4.Y1 - height; 
            Line4.Stroke = color;
            Line4.StrokeThickness = strokeThickness;

            // Set initial coordinates to avoid distortion while rotating
            InitialX1 = X1; 
            InitialX2 = X2; 
            InitialX3 = X3; 
            InitialX4 = X4; 
            InitialY1 = Y1; 
            InitialY2 = Y2; 
            InitialY3 = Y3; 
            InitialY4 = Y4; 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to place rectangle to the initial points
        /// </summary>
        public void PlaceToInitialPoints()
        {
            this.X1 = this.InitialX1; 
            this.X2 = this.InitialX2; 
            this.X3 = this.InitialX3; 
            this.X4 = this.InitialX4; 
            this.Y1 = this.InitialY1; 
            this.Y2 = this.InitialY2; 
            this.Y3 = this.InitialY3; 
            this.Y4 = this.InitialY4; 
        }
        #endregion  // Methods
    }
}