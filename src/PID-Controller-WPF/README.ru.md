# PID-Controller-WPF

[English](README.md) | [Русский](README.ru.md)

`PID-Controller-WPF` — это проект, который предоставляет среду моделирования для тестирования и оптимизации параметров ПИД-регулятора для различных систем управления.

## Общее описание

Этот проект предназначен для моделирования **ПИД-регулятора** для регулирования *переменной процесса* в зависимости от *уставки*.

Например, если вам необходимо убедиться, что *реальная скорость автомобиля* соответствует значению *желаемой скорости*, то приложение `PID-Controller-WPF` может быть полезно при выборе параметров ** ПИД-регулятор**.

Это приложение написано на языке программирования C# с использованием шаблона **MVVM**.

![MainWindow](docs/img/Usage/MainWindow.png)

### Цель

Целью проекта является создание программного приложения, которое моделирует ПИД-регулятор для регулирования переменной процесса в зависимости от заданного значения.

### Область применения

В область применения проекта входит разработка приложения WPF на C# с использованием шаблона MVVM для моделирования ПИД-регулятора и обеспечения выбора параметров контроллера для конкретных приложений.

### Кто может использовать этот проект

Этот проект могут использовать инженеры, исследователи или все, кто занимается управлением и автоматизацией процессов, которым необходимо оптимизировать параметры ПИД-регулятора для различных систем.

### Возможные ограничения

Возможные ограничения этого проекта могут включать проблемы с точным моделированием сложных систем управления, потенциальные ограничения в области приложений систем управления, которые можно моделировать, а также необходимость обширных испытаний для обеспечения точности и надежности моделируемого ПИД-регулятора.

## Отрывки кода 

### Добавление новых элементов на график

Если Вы хотите добавить новый визуальный элемент на график (например, точки для SP и PV), Вам для начала необходимо в конструкторе класса `MainWindow` установить в ноль занчения `GraphCanvasVM.Setpoint` и `GraphCanvasVM.ProcessVariable`, после чего вызвать метод `DrawCoordinates()`, который позволит прорисовать координатную сетку и установить подписи к осям. 
```C#
namespace PidControllerWpf.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ... 
            // When canvas is loaded, get size of Graph using lambda expression.
            Loaded += (o, e) => 
            {
                ...
                // Pass width and height of a canvas to the GraphCanvasVM 
                ((MainWindowVM)(this.DataContext)).GraphCanvasVM.Setpoint = 0; 
                ((MainWindowVM)(this.DataContext)).GraphCanvasVM.ProcessVariable = 0; 

                // Draw coordinates 
                DrawCoordinates();
                ...
            }; 
        }
        ... 
    }
}
```

После этого нужно перейти в `GraphCanvasVM`и определить булевые переменные `IsSpMovedToInitPoint` и `IsPvMovedToInitPoint`, которые используются для того, чтобы определить, были ли точки для SP и PV передвинуты в *начало координат*. 
```C#
namespace PidControllerWpf.ViewModels
{
    public class GraphCanvasVM : INotifyPropertyChanged
    {
        ...
        /// <summary>
        /// Boolean variable that shows if SP moved to (0,0) point on coordinates
        /// </summary>
        public bool IsSpMovedToInitPoint
        {
            get { return isSpMovedToInitPoint; }
            set { isSpMovedToInitPoint = (!value && !isSpMovedToInitPoint) ? false : true; }
        }

        /// <summary>
        /// Boolean variable that shows if PV moved to (0,0) point on coordinates
        /// </summary>        
        private bool isPvMovedToInitPoint = false; 
        public bool IsPvMovedToInitPoint
        {
            get { return isPvMovedToInitPoint; }
            set { isPvMovedToInitPoint = (!value && !isPvMovedToInitPoint) ? false : true; }
        }
        
        public bool IsEverStarted
        {
            get { return IsSpMovedToInitPoint && IsPvMovedToInitPoint; }
        }

        private double processVariable;
        public double ProcessVariable
        {
            get { return processVariable; }
            set 
            { 
                this.DrawVariable(ref value, false, true); 

                // Draw all lines 
                MainWindow.DrawCoordinates(); 
                MainWindow.DrawLine(SetpointLines);
                MainWindow.DrawLine(ProcessVarLines);
                
                processVariable = value; 
            }
        }
                
        private double setpoint; 
        /// <summary>
        /// Allows to move setpoint on the graph according to 
        /// the scale of a graph 
        /// </summary>
        public double Setpoint
        {
            get { return setpoint; } 
            set
            {
                this.DrawVariable(ref value, true, false); 

                // Draw all lines 
                MainWindow.DrawCoordinates(); 
                MainWindow.DrawLine(SetpointLines);
                MainWindow.DrawLine(ProcessVarLines);
                
                setpoint = value; 
            }
        }
        ...
        /// <summary>
        /// Clears all lists of lines used for drawing SP and PV
        /// </summary>
        public void ClearListOfLines()
        {
            SetpointLines.Clear();          // Clear list of lines
            ProcessVarLines.Clear();        // Clear list of lines
            MainWindow.DrawCoordinates();   // Draw line 
        }

        /// <summary>
        /// Allows to draw SP and PV
        /// </summary>
        private void DrawVariable(ref double value, bool isSetpoint, bool isPv)
        {
            double min = MainWindow.MinPvGraph; 
            double max = MainWindow.MaxPvGraph; 
            double VarLeft = 0; 
            double VarTop = 0; 
            Point ReferencePoint = new Point(); 
            List<Line> lines = null; 
            System.Windows.Media.Brush color = null; 

            // Assign variables for SP and PV setting
            if (isSetpoint)
            {
                VarLeft = this.SetpointLeft; 
                VarTop = this.SetpointTop; 
                ReferencePoint = this.SpRefPoint; 
                lines = this.SetpointLines; 
                color = System.Windows.Media.Brushes.Red; 
            }
            else if (isPv)
            {
                VarLeft = this.ProcessVariableLeft; 
                VarTop = this.ProcessVariableTop; 
                ReferencePoint = this.PvRefPoint; 
                lines = this.ProcessVarLines; 
                color = System.Windows.Media.Brushes.Blue; 
            }
            ...
            try
            {
                // Correct a list of lines 
                if (!IsTimerEnabled)
                {
                    // Assign ReferencePoint for the first time 
                    if (IsEverStarted)
                    {
                        ...
                    }
                    else
                    {
                        ReferencePoint = new Point(line.X2, line.Y2);

                        if (isSetpoint)
                        {
                            IsSpMovedToInitPoint = true; 
                        }
                        else if (isPv)
                        {
                            IsPvMovedToInitPoint = true; 
                        }
                    }
                else
                {
                    ...
                }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception"); 
            }

            // Reassign variables for SP and PV setting
            if (isSetpoint)
            {
                this.SetpointLeft = VarLeft; 
                this.SetpointTop = VarTop; 
                this.SpRefPoint = ReferencePoint; 
                this.SetpointLines = lines; 
            }
            else if (isPv)
            {
                this.ProcessVariableLeft = VarLeft; 
                this.ProcessVariableTop = VarTop; 
                this.PvRefPoint = ReferencePoint; 
                this.ProcessVarLines = lines; 
            }
        }
        ...
    }
}
```

Также нужно добавить функционал для **сброса таймера** и возвращения всех визуальных элементов (точек) в *начало координат*. 
Для этого в классе `TimerCommand` необходимо прописать следующее: 
```C#
namespace PidControllerWpf.Commands
{
    class TimerCommand : ICommand
    {
        ...
        public void Execute(object parameter)
        {
            try
            {
                // Stop timer 
                this._PidVM.TimerGraph.Stop(); 
                
                // Assign `GraphCanvasVM` as `gcvm` for convinience 
                GraphCanvasVM gcvm = this._PidVM.GraphCanvasVM; 

                // Say that timer is not enabled 
                gcvm.IsTimerEnabled = false; 

                // Set size of a window
                MainWindow.MinTimeGraph = 0; 
                MainWindow.MaxTimeGraph = 60; 

                // Set SP to zero 
                gcvm.Setpoint = 0; 
                _PidVM.TextBlockVM.SetPointTextBlock = $"{gcvm.Setpoint}"; 
                
                // Set PV to zero 
                gcvm.ProcessVariable = 0; 
                _PidVM.TextBlockVM.ProcessVariableTextBlock = $"{gcvm.ProcessVariable}"; 

                // Set time to zero
                gcvm.Time = 0; 
                _PidVM.TextBlockVM.TimeTextBlock = $"{gcvm.Time}";

                // Set reference point to be able to change SP while timer isn't enabled
                Point refpoint = new Point(gcvm.SetpointLeft, gcvm.SetpointTop + 2.5); 
                gcvm.SpRefPoint = refpoint; 

                // Clear list of lines 
                gcvm.ClearListOfLines(); 
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
    }
}
```
