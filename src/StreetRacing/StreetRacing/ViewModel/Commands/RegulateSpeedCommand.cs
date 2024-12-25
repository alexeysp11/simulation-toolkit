using System;
using StreetRacing.ViewModel;

namespace StreetRacing.Commands
{
    public class RegulateSpeedCommand : System.Windows.Input.ICommand
    {
        private SpeedometerVM _SpeedometerVM { get; set; }

        public RegulateSpeedCommand(SpeedometerVM speedometerVM)
        {
            this._SpeedometerVM = speedometerVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            double deltaSpeed = 0; 

            // Interpret parameter
            string direction = parameter as string;
            if (direction == "Increase")
            {
                deltaSpeed = 1; 
            }
            else if (direction == "Decrease")
            {
                deltaSpeed = -1; 
            }

            this._SpeedometerVM.RotateSpeedometerArrow(deltaSpeed); 
        }
    }
}