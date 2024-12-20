using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool IsDrawing;
        private int currentTool = 0;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = true;
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = false;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                Draw(e.GetPosition(CnvPaint));
            }
        }
        private void Draw(Point position)
        {
            Ellipse elipse = new Ellipse();
            elipse.Fill = Brushes.Aqua;
            elipse.Width = 10;
            elipse.Height = 10;
            Canvas.SetTop(elipse, position.Y);
            Canvas.SetLeft(elipse, position.X);
            CnvPaint.Children.Add(elipse);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Btnpencil.Background = Brushes.LightGray;
            Btnrubber.Background = Brushes.LightGray;
            Btndrip.Background = Brushes.LightGray;
            Button button = (Button) sender;
            button.Background = Brushes.Yellow;
            if (button == Btnpencil)
            {
                currentTool = 0;
                
                SliderSize.Visibility = Visibility.Visible;
                ColorPicker.Visibility = Visibility.Visible;
            }
            if (button == Btnrubber)
            {
                currentTool = 1;
                SliderSize.Visibility = Visibility.Visible;
                ColorPicker.Visibility = Visibility.Hidden;
            }
            if (button == Btndrip)
            {
                currentTool = 2;
                SliderSize.Visibility = Visibility.Visible;
                ColorPicker.Visibility = Visibility.Visible; 
            }

        }
    }
}
