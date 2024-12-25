using System;
using StreetRacing.ViewModel;

namespace StreetRacing.Commands
{
    class RotateSteeringWheelCommand : System.Windows.Input.ICommand
    {
        public SteeringWheelVM _SteeringWheelVM { get; private set; }

        public RotateSteeringWheelCommand(SteeringWheelVM steeringWheelVM)
        {
            _SteeringWheelVM = steeringWheelVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            double angle = 5; 

            string direction = parameter as string;
            if (direction == "Left")
            {
                angle *= -1;
            }
            _SteeringWheelVM.RotateElementsOfSteeringWheel(angle); 
        }
    }
}