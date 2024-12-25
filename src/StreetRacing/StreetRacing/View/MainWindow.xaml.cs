using System.Windows;
using StreetRacing.ViewModel; 

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
