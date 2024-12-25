using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading; 

namespace Simulation3d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        private PhysicalModel3D PhysicalModel = new PhysicalModel3D(); 
        private ComPort ComPort = null; 

        /// <summary>
        /// This timer is used for updating labels for displaying rotation
        /// angle, acceleration and temperature in the current moment. 
        /// </summary>
        private DispatcherTimer updateLabelsTimer = null; 
        /// <summary>
        /// This timer is used to timely clear InfoLabel (notification label). 
        /// </summary>
        private DispatcherTimer clearInfoLabelTimer = null; 
        
        private Angle angle;
        private Acceleration accel;
        #endregion  // Members

        #region Properties
        private float temperature;
        private bool IsSimalation = true; 
        /// <summary>
        /// Variable that stores name of connected COM-port for preventing 
        /// change of COM-port while it's connected. 
        /// </summary>
        private string ComPortText = null; 
        #endregion  // Properties

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            this.ComPort = new ComPort(InfoLabel, ref PhysicalModel);

            // updateLabelsTimer starts when window is loaded and updates 
            // every 100 ms. 
            updateLabelsTimer = new System.Windows.Threading.DispatcherTimer();
            updateLabelsTimer.Tick += (sender, args) => {
                // Adjust acceleration because acceleration cannot be the same
                // if the state of a real life object does not change.
                //PhysicalModel.AdjustAcceleration();
                
                // Get acceleration, rotation angle and temperature. 
                this.accel = PhysicalModel.GetAcceleration();
                this.angle = PhysicalModel.GetRotation();
                this.temperature = PhysicalModel.GetTemperature(); 

                // Rotate 3D model. 
                Model3dRotateAngleX.Angle = this.angle.X;
                Model3dRotateAngleY.Angle = this.angle.Y;
                Model3dRotateAngleZ.Angle = this.angle.Z;

                // Display rotation angle. 
                AngleX.Content = $"{angle.X}"; 
                AngleY.Content = $"{angle.Y}"; 
                AngleZ.Content = $"{angle.Z}";
                
                // Display acceleration. 
                AccelX.Content = $"{accel.X}"; 
                AccelY.Content = $"{accel.Y}"; 
                AccelZ.Content = $"{accel.Z}";
                
                // Display temperature. 
                TemperatureLabel.Content = $"{temperature}"; 
            }; 
            updateLabelsTimer.Interval = TimeSpan.FromSeconds(0.1);

            // Clear InfoLabel after 5 seconds when user clicked on Connect
            // or Disconnect, then it stops. 
            clearInfoLabelTimer = new System.Windows.Threading.DispatcherTimer();
            clearInfoLabelTimer.Tick += (sender, args) => {
                InfoLabel.Content = ""; 
                clearInfoLabelTimer.Stop();
            };
            clearInfoLabelTimer.Interval = TimeSpan.FromSeconds(3);

            Loaded += (sender, args) => {
                updateLabelsTimer.Start();  // Start updating notifications. 
            };

            myCanvas.Focus();
        }
        #endregion  // Constructors

        #region UI buttons handling
        /// <summary>
        /// If Refresh button was pressed, get all available COM-ports.  
        /// </summary>
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsSimalation)  // Do nothing if it's a simualtion mode. 
            {
                System.Windows.MessageBox.Show("Unable to refresh COM-ports in simulation mode.");
                return; 
            }

            // Refresh only when COM-port is not connected. 
            if (!this.ComPort.IsConnected)
            {
                // Not to copy one COM port multiple times. 
                ComPortsComboBox.Items.Clear();

                // `ComPort.Ports` is the array of COM ports. 
                string[] arrayOfPorts = ComPort.Ports;

                // Create new instances of COM ports. 
                for (int i = 0; i < arrayOfPorts.Length; i++)
                {
                    ComPortsComboBox.Items.Add(arrayOfPorts[i]); 
                }
            }
            else
            {
                System.Windows.MessageBox.Show("COM-port is already connected!");
            }
        }

        /// <summary>
        /// Disable DropDown when COM-port is already selected, and enable 
        /// DropDown when COM-port is not selected. 
        /// </summary>
        private void ComPortsComboBox_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (this.ComPortText == null)
            {
                cb.IsDropDownOpen = true;
            }
            else
            {
                cb.IsDropDownOpen = false;
            }
        }

        /// <summary>
        /// Connects or disconnects selected COM-port and changes content of 
        /// a button that was pressed (from `Connect` to `Disconnect` and 
        /// vica versa). 
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown when an instance of `ComPort` class is not created. 
        /// </exception>
        private void ConnectDisconnectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsSimalation)  // Do nothing if it's a simulation mode. 
            {
                System.Windows.MessageBox.Show("Unable to connect COM-ports in simulation mode.");
                return; 
            }

            clearInfoLabelTimer.Start();    // Start timer for updating labels. 

            if (this.ComPort.IsConnected)
            {
                try
                {
                    this.ComPort.Close();
                    this.ComPortText = null; 
                    ConnectDisconnectBtn.Content = "Connect"; 
                }
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show($"Exception: {ex}", "Exception"); 
                }
            }
            else
            {
                try
                {
                    this.ComPort.Config(ComPortsComboBox.Text);
                    this.ComPort.Open();
                    this.ComPortText = ComPortsComboBox.Text; 

                    // Change label only if COM-port is connected. 
                    if (this.ComPort.IsConnected)
                    {
                        ConnectDisconnectBtn.Content = "Close"; 
                    }
                }
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show($"Exception: {ex}", "Exception"); 
                }
            }
        }
        #endregion  // UI buttons handling

        #region Keyboard handling
        /// <summary>
        /// If user pressed some key. 
        /// </summary>
        private void KeyUp_Handling(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.M)         // Change mode (from simulation to measuring and vica versa). 
            {
                if (this.ComPort.IsConnected)
                {
                    System.Console.WriteLine("Unable to change mode while COM-port is connected.");
                    return;
                }
                else
                {
                    this.IsSimalation = !this.IsSimalation;
                }
            }

            if (this.IsSimalation)
            {
                ModeLabel.Content = "MODE: simulation"; 
            }
            else
            {
                ModeLabel.Content = "MODE: measurement"; 
                return; 
            }

            if (e.Key == Key.E)         // Rotation around X axis.
            {
                PhysicalModel.SetRotation(5, 0, 0); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleX.Angle = this.angle.X; 
            }
            else if (e.Key == Key.Q)    // Rotation around X axis.
            {
                PhysicalModel.SetRotation(-5, 0, 0); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleX.Angle = this.angle.X; 
            }
            else if (e.Key == Key.R)    // Rotation around Y axis.
            {
                PhysicalModel.SetRotation(0, 5, 0); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleY.Angle = this.angle.Y; 
            }
            else if (e.Key == Key.F)    // Rotation around Y axis.
            {
                PhysicalModel.SetRotation(0, -5, 0); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleY.Angle = this.angle.Y; 
            }
            else if (e.Key == Key.X)    // Rotation around Z axis.
            {
                PhysicalModel.SetRotation(0, 0, 5); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleZ.Angle = this.angle.Z; 
            }
            else if (e.Key == Key.Z)    // Rotation around Z axis.
            {
                PhysicalModel.SetRotation(0, 0, -5); 
                this.angle = PhysicalModel.GetRotation(); 
                Model3dRotateAngleZ.Angle = this.angle.Z; 
            }
            else if (e.Key == Key.A)    // Left (acceleration). 
            {
                PhysicalModel.SetAcceleration(-5, 0, 0);
                this.accel = PhysicalModel.GetAcceleration();
            }
            else if (e.Key == Key.D)    // Right (acceleration). 
            {
                PhysicalModel.SetAcceleration(5, 0, 0);
                this.accel = PhysicalModel.GetAcceleration();
            }
            else if (e.Key == Key.W)    // Up (acceleration). 
            {
                PhysicalModel.SetAcceleration(0, 5, 0);
                this.accel = PhysicalModel.GetAcceleration();
            }
            else if (e.Key == Key.S)    // Down (acceleration). 
            {
                PhysicalModel.SetAcceleration(0, -5, 0);
                this.accel = PhysicalModel.GetAcceleration();
            }
            else if (e.Key == Key.C)    // Up (acceleration). 
            {
                PhysicalModel.SetAcceleration(0, 0, 5);
                this.accel = PhysicalModel.GetAcceleration();
            }
            else if (e.Key == Key.V)    // Down (acceleration). 
            {
                PhysicalModel.SetAcceleration(0, 0, -5);
                this.accel = PhysicalModel.GetAcceleration();
            }

            myCanvas.Focus();
        }
        #endregion  // Keyboard handling
    }
}
