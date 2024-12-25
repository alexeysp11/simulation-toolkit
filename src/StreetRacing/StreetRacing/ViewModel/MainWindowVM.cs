using StreetRacing.View; 

namespace StreetRacing.ViewModel
{
    /// <summary>
    /// Allows to interact with all ViewModels defined in the application 
    /// </summary>
    public class MainWindowVM
    {
        #region ViewModels
        /// <summary>
        /// Private field for interacting with SpeedometerVM
        /// </summary>
        private SpeedometerVM _SpeedometerVM;
        /// <summary>
        /// Public property for interacting with SpeedometerVM
        /// </summary>
        /// <value>Readonly property that gets value of _SpeedometerVM</value>
        public SpeedometerVM SpeedometerVM
        {
            get { return _SpeedometerVM; }
        }

        /// <summary>
        /// Private field for interacting with SteeringWheelVM
        /// </summary>
        private SteeringWheelVM _SteeringWheelVM;
        /// <summary>
        /// Public property for interacting with SteeringWheelVM
        /// </summary>
        /// <value>Readonly property that gets value of _SteeringWheelVM</value>
        public SteeringWheelVM SteeringWheelVM
        {
            get { return _SteeringWheelVM; }
        }

        /// <summary>
        /// Private field for interacting with CabinVM
        /// </summary>
        private CabinVM _CabinVM;
        /// <summary>
        /// Public property for interacting with CabinVM
        /// </summary>
        /// <value>Readonly property that gets value of _CabinVM</value>
        public CabinVM CabinVM
        {
            get { return _CabinVM; }
        }

        /// <summary>
        /// Private field for interacting with RoadVM
        /// </summary>
        private RoadVM _RoadVM;
        /// <summary>
        /// Public property for interacting with RoadVM
        /// </summary>
        /// <value>Readonly property that gets value of _RoadVM</value>
        public RoadVM RoadVM
        {
            get { return _RoadVM; }
        }

        /// <summary>
        /// Private field for interacting with MapVM
        /// </summary>
        private MapVM _MapVM;
        /// <summary>
        /// Public property for interacting with MapVM
        /// </summary>
        /// <value>Readonly property that gets value of _MapVM</value>
        public MapVM MapVM
        {
            get { return _MapVM; }
        }
        #endregion  // ViewModels
        
        #region Constructor
        /// <summary>
        /// Constructor of MainWindowVM
        /// </summary>
        /// <param name="window">Instance of MainWindow</param>
        public MainWindowVM(MainWindow window)
        {
            this._SpeedometerVM = new SpeedometerVM(window); 
            this._SteeringWheelVM = new SteeringWheelVM(window); 
            this._CabinVM = new CabinVM(window); 
            this._RoadVM = new RoadVM(window); 
            this._MapVM = new MapVM(window); 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Method for drawing all visual elements on the MainCanvas. 
        /// Is invoked when Load event of MainWindow occurs.
        /// </summary>
        public void DrawVisualElements()
        {
            this.RoadVM.DrawRoad(); 
            this.CabinVM.DrawCabinOnCanvas(); 
            this.SpeedometerVM.DrawVisualElementsOfSpeedometer(); 
            this.SteeringWheelVM.DrawSteeringWheelOnCanvas(); 
            this.MapVM.DrawMap(); 
        }
        #endregion  // Methods
    }
}