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
        private int size = 1;
        private Brush color;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDrawing = true;
            if (currentTool == 0 )
            {
                Draw(e.GetPosition(CnvPaint));
            }
            if (currentTool == 1)
            {
                Erase(e.GetPosition(CnvPaint));
            }
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
            if (currentTool == 1)
            {
                Erase(e.GetPosition(CnvPaint));
            }


        }
        private void Draw(Point position)
        {
            Ellipse elipse = new Ellipse();
            elipse.Fill = color;
            elipse.Width = size;
            elipse.Height = size;
            Canvas.SetTop(elipse, position.Y -  elipse.Height / 2);
            Canvas.SetLeft(elipse, position.X - elipse.Width / 2 );
            CnvPaint.Children.Add(elipse); 



        }
        private void Erase(Point position)
        {
            IsDrawing = false ;

            Rect erase = new Rect();
            erase.Width = size;
            erase.Height = size;
            Point Place = new Point(position.X - erase.Width / 2, position.Y - erase.Height);
            erase.Location = Place; 
            for     (int i = 0; i < CnvPaint.Children.Count; i++)
            {
                Rect point = new Rect();
                point.Size = CnvPaint.Children[i].RenderSize;
                point.Location = new Point(
                 Canvas.GetLeft(CnvPaint.Children[i]),
                 Canvas.GetTop(CnvPaint.Children[i])
                 );

                if (erase.IntersectsWith(point))
                {
                    CnvPaint.Children.RemoveAt(i);
                    i--;
                }
            }

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

        private void SliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            size = (int)SliderSize.Value;
        }

        private void ColorPicker_Selected(object sender, RoutedEventArgs e)
        {


        }

        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               switch(ColorPicker.SelectedIndex)
            {
                case 0:
                    color = Brushes.Black;

                    break;
                    case 1:
                    color =Brushes.Red;

                     break;
                    case 2:
                    color = Brushes.Green;

                    break;
                    case 3:
                    color = Brushes.Blue;
                    break;
                    default:
                    color = Brushes.Black;

                    break;

            }
               

        }
    }
}
