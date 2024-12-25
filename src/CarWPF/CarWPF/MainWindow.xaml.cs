using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading; 

namespace CarWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Control movements of a car

        ///<summary>
        /// Should a car go left now. 
        /// This variable is used when user pressed a left arrow button. 
        ///</summary>
        bool isGoLeft = false;
        ///<summary>
        /// Should a car go right now. 
        /// This variable is used when user pressed a right arrow button. 
        ///</summary>
        bool isGoRight = false; 
        ///<summary>
        /// Should a car go up now. 
        /// This variable is used when user pressed an up arrow button. 
        ///</summary>
        bool isGoUp = false; 
        ///<summary>
        /// Should a car go down now. 
        /// This variable is used when user pressed a down arrow button. 
        ///</summary>
        bool isGoDown = false;
        /// <summary>
        /// Standard speed of a car.
        /// </summary>
        int speed = 5;

        #endregion


        #region Control of a program flow

        /// <summary>
        /// If a user pressed New button.
        /// </summary>
        bool isNew = false;
        /// <summary>
        /// If a user pressed Pause button.
        /// </summary>
        bool isPause = false;
        /// <summary>
        /// If a user pressed Continue button.
        /// </summary>
        bool isContinue = false;
        /// <summary>
        /// If a user pressed Exit button.
        /// </summary>
        bool isExit = false;
        /// <summary>
        /// Dispatcher timer for buttons handling. 
        /// </summary>
        DispatcherTimer gameTimer = new DispatcherTimer();

        #endregion


        /// <summary>
        /// Main Window constructor invokes `VisualsDB.GetRoad()` method 
        /// responding for requests to the DB for getting information about 
        /// visual elements, invokes `DrawRoad()` for drawing these visual elements
        /// and starts a timer. 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Get visual elements from DB and draw them on the canvas. 
            DrawRoad(VisualsDB.GetRoad(RequestsToDb.path, RequestsToDb.getRoad), myCanvas); 

            // Focus to the canvas. 
            myCanvas.Focus(); 

            // Configure and start main timer. 
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }
        
        /// <summary>
        /// Gets a list of instances of RoadElement class, creates visual 
        /// element for representing each of these instances.
        /// </summary>
        /// <param name="road">List of instances of RoadElement class.</param>
        /// <param name="myCanvas">Reference to the main canvas.</param>
        private static void DrawRoad(List<RoadElement> road, Canvas myCanvas)
        {
            // Declare an instance of `Line`. 
            Line line; 

            // Iterate through each element of the `List<RoadElement>` named `road`. 
            foreach (var item in road)
            {
                // Create an instance of an element. 
                line = new Line();

                // Set coordinates of a line. 
                line.X1 = item.X1;
                line.X2 = item.X2;
                line.Y1 = item.Y1;
                line.Y2 = item.Y2;

                // Set color of an element. 
                line.Stroke = System.Windows.Media.Brushes.Black;

                // Set thickness of a line. 
                if (item.Name == "Border")
                {
                    line.StrokeThickness = 2;
                }
                else
                {
                    line.StrokeThickness = 1;
                }

                // Set dashes for center line. 
                if (item.Name == "Center")
                {
                    line.StrokeDashArray = new DoubleCollection() { 2 }; 
                }

                // Add an element to the Canvas. 
                myCanvas.Children.Add(line);
            }
        }

        /// <summary>
        /// Moves a player box until it gets the end point and handles if a car 
        /// intercects any border. 
        /// </summary>
        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (isGoLeft == true && Canvas.GetLeft(player) > 5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }
            else if (isGoRight == true && Canvas.GetLeft(player) + (player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }
            else if (isGoUp == true && Canvas.GetTop(player) > 5)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - speed);
            }
            else if (isGoDown == true && Canvas.GetTop(player) + (player.Height + 45) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            }
        }

        /// <summary>
        /// Sets true to the boolean variables that define directions if 
        /// necessary key is down.
        /// </summary>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                isGoLeft = true;
            }
            else if (e.Key == Key.D)
            {
                isGoRight = true;
            }
            else if (e.Key == Key.W)
            {
                isGoUp = true;
            }
            else if (e.Key == Key.S)
            {
                isGoDown = true;
            }
            else if (e.Key == Key.N)
            {
                isNew = true;
            }
            else if (e.Key == Key.P)
            {
                isPause = true;
            }
            else if (e.Key == Key.C)
            {
                isContinue = true;
            }
            else if (e.Key == Key.Q)
            {
                isExit = true;
            }
        }

        /// <summary>
        /// Sets false to the boolean variables that define directions if 
        /// necessary key is up.
        /// </summary>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                isGoLeft = false;
            }
            else if (e.Key == Key.D)
            {
                isGoRight = false;
            }
            else if (e.Key == Key.W)
            {
                isGoUp = false;
            }
            else if (e.Key == Key.S)
            {
                isGoDown = false;
            }
            else if (e.Key == Key.N)
            {
                isNew = false;
            }
            else if (e.Key == Key.P)
            {
                isPause = false;
            }
            else if (e.Key == Key.C)
            {
                isContinue = false;
            }
            else if (e.Key == Key.Q)
            {
                isExit = false;
            }
        }

        /// <summary>
        /// If New button was clicked, draw new page or relocate a car. 
        /// </summary>
        private void newBtn_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("New button was clicked.");
        }

        /// <summary>
        /// If Pause button was clicked, stop to execute the application.  
        /// </summary>
        private void pauseBtn_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Pause button was clicked.");
        }

        /// <summary>
        /// If Continue button was clicked, continue to execute the application.  
        /// </summary>
        private void continueBtn_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Continue button was clicked.");
        }

        /// <summary>
        /// If Exit button was clicked, exit the application.  
        /// </summary>
        private void exitBtn_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Exit button was clicked.");
        }
    }
}