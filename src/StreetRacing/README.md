# StreetRacing

`StreetRacing` is a project that is written in `C#` with **WPF** using **MVVM** pattern. 

## How to use

### Prerequisites

- Windows OS;
- .NET Core 3.1;
- Any text editor (*VS Code*, *Sublime Text*, *Notepad++* etc) or Visual Studio;
- Windows command line (if you do not use Visual Studio).

### How to download this repository and edit code

In order to download this repository, just type into console the following command:
```
git clone https://github.com/alexeysp11/StreetRacing
```

Then just open main directory using any text editor and edit code.

In order to open this application with Visual Studio, just open `StreetRacing.sln` solution by double click. 

### How to run

If you are not using Visual Studio, you can run the app using Windows command line. 
So just write the following command into console:
```
run.cmd
```

## Code snippets 

Because of that `WindowState` is set to `Maximized`, sizes of all visual elements in the app should be relative to *width* and *height* of the canvas `MainCanvas`. 
So, first of all, it's necessary to get *width* and *height* of the canvas when it's already rendered and ready for interaction. 

You can do that by handling event `Loaded` using lambda expression and calling method `DrawVisualElements()` of `MainWindowVM`, as shown below: 
```C#
namespace StreetRacing.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM(this); 

            /* When window is loaded, draw all visual elements on the Canvas 
            using lambda expression. */
            Loaded += (o, e) => 
            {
                ((MainWindowVM)(this.DataContext)).DrawVisualElements(); 
            }; 
        }
    }
}
```

In the `MainWindowVM.DrawVisualElements()` just invoke methods for drawing a *road*, *cabin of a car*, *speedometer*, *steering wheel*, *map* etc.: 
```C#
namespace StreetRacing.ViewModel
{
    public class MainWindowVM
    {
        ... 
        public void DrawVisualElements()
        {
            this.RoadVM.DrawRoad(); 
            this.CabinVM.DrawCabinOnCanvas(); 
            this.SpeedometerVM.DrawVisualElementsOfSpeedometer(); 
            this.SteeringWheelVM.DrawSteeringWheelOnCanvas(); 
            this.MapVM.DrawMap(); 
        }
    }
}
```
