using StreetRacing.View; 

namespace StreetRacing.ViewModel
{
    /// <summary>
    /// Class for interacting with a map 
    /// </summary>
    public class MapVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Constructor
        /// <summary>
        /// Constructor of MapVM
        /// </summary>
        /// <param name="window">Instance of MainWindow</param>
        public MapVM(MainWindow window)
        {
            _MainWindow = window; 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to draw map at lower left corner of the screen
        /// </summary>
        public void DrawMap()
        {

        }
        #endregion  // Methods
    }
}