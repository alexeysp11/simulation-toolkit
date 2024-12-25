using System;
using System.Windows.Controls; 
using System.Windows.Media; 
using System.Windows.Documents; 
using System.IO.Ports;

namespace Simulation3d
{
    public class ComPort
    {
        private PhysicalModel3D PhysicalModel = null; 
        protected SerialPort comPort = new SerialPort();  
        protected Label InfoLabel = null; 
        private object Obj = new object();

        public static string[] Ports { get { return SerialPort.GetPortNames(); } }
        public bool IsConnected { get; private set; }
        private static int PacketSize = 6; 

        public ComPort(Label infoLabel, ref PhysicalModel3D physicalModel)
        {
            PhysicalModel = physicalModel;
            InfoLabel = infoLabel;

            comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            
            IsConnected = false; 
        }

        public void Config(string portName, string baudRate="19200", 
            string parity="None", string stopBitsNumber="1")
        {
            if (comPort.IsOpen == true) 
            {
                this.Close(); 
            }

            try
            {
                comPort.PortName = portName;
                comPort.BaudRate = Int32.Parse(baudRate);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsNumber);
                comPort.DataBits = 8;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Exception: {ex}", "Exception");
            }
        }

        public bool Open()
        {
            try
            {
                comPort.Open();
                this.DisplayData(Brushes.Black, "Port " + comPort.PortName + " is opened at " + DateTime.Now);
                IsConnected = true; 
                return true;
            }
            catch (System.UnauthorizedAccessException)
            {
                comPort.Close();
                this.DisplayData(Brushes.Black, "Port " + comPort.PortName + " is closed at " + DateTime.Now);
                
                comPort.Open();
                this.DisplayData(Brushes.Black, "Port " + comPort.PortName + " is opened at " + DateTime.Now);
                IsConnected = true; 
                return true;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Exception: {ex}", "Exception");
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                comPort.Close();
                this.DisplayData(Brushes.Black, "Port " + comPort.PortName + " is closed at " + DateTime.Now);
                IsConnected = false;
                return true;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Exception: {ex}", "Exception");
                return false;
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (Obj)
                {
                    byte[] comBuffer = new byte[24];
                    comPort.Read(comBuffer, 0, comBuffer.Length);
                    this.DecodeMeasuredData(comBuffer); 
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Exception: {ex}", "Exception"); 
            }
        }

        private void DecodeMeasuredData(byte[] comByte)
        {
            byte tempSensor     = 0b00000000 | 0b00000100; 
            byte accelerometerX = 0b10000000 | 0b00100000; 
            byte accelerometerY = 0b10000000 | 0b00010000; 
            byte accelerometerZ = 0b10000000 | 0b00001000; 

            string message = string.Empty; 
            float dx = 0; 
            float dy = 0;
            float dz = 0; 

            for (int i = 0; i < comByte.Length; i++)
            {
                if (i % PacketSize == 0) 
                {
                    if (comByte[i] == tempSensor)
                    {
                        message += "Temperature: ";
                        float value = System.BitConverter.ToSingle(comByte, i+1);     // Get 4 bytes. 
                        PhysicalModel.SetTemperature(value);
                        message += $"{value}"; 
                        message += $"{comByte[i+5]}"; 
                    }
                    else if (comByte[i] == accelerometerX)
                    {
                        message += " AccelX: ";
                        dx = System.BitConverter.ToSingle(comByte, i+1);     // Get 4 bytes. 
                        message += $"{dx}"; 
                        message += $"{comByte[i+5]}"; 
                    }
                    else if (comByte[i] == accelerometerY)
                    {
                        message += " AccelY: ";
                        dy = System.BitConverter.ToSingle(comByte, i+1);     // Get 4 bytes. 
                        message += $"{dy}"; 
                        message += $"{comByte[i+5]}"; 
                    }
                    else if (comByte[i] == accelerometerZ)
                    {
                        message += " AccelZ: ";
                        dz = System.BitConverter.ToSingle(comByte, i+1);     // Get 4 bytes. 
                        message += $"{dz}"; 
                        message += $"{comByte[i+5]}"; 
                    }
                }
            }
            PhysicalModel.SetAcceleration(dx, dy, dz);
            this.DisplayData(Brushes.Green, message);
        }

        protected void DisplayData(Brush color, string msg)
        {
            if (InfoLabel != null)
            {
                InfoLabel.Dispatcher.Invoke(() => {
                    InfoLabel.Content = msg; 
                    InfoLabel.Foreground = color; 
                });
            }
        }
    }
}
