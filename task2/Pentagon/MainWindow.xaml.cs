using System.Windows;
using System.Windows.Shapes;
using Task2.Service;
using Task2.Domain;
using System.Windows.Media;
using System.Windows.Forms;
using System;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CanvasService CanvasService = new CanvasService();
        private Canvas Canvas = new Canvas();
        private Pentagon CurrentPentagon = new Pentagon();
        private Domain.Point LastPoint;
        private Line FollowLine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCanvas(object sender, RoutedEventArgs e)
        {
            ResetCanvas();
        }

        private void OpenSavedCanvas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ResetCanvas();
                string filePath = System.IO.Path.GetFullPath(dialog.FileName);
                Canvas = CanvasService.Get(filePath);
                foreach (Pentagon pentagon in Canvas.Pentagons)
                {
                    DrawPentagon(pentagon);
                }
            }
        }

        private void ResetCanvas()
        {
            DrawCanvas.Children.Clear();
            DrawCanvas.Visibility = Visibility.Visible;
            Canvas = new Canvas();
            CurrentPentagon = new Pentagon();
            LastPoint = null;
            FollowLine = null;
        }

        private void SaveCanvas(object sender, RoutedEventArgs e)
        {
            if (Canvas.Pentagons.Count == 0)
            {
                System.Windows.MessageBox.Show("Nothing to save", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = System.IO.Path.GetFullPath(dialog.FileName);
                CanvasService.Save(Canvas, filePath);
            }
        }

        private void CanvasClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LastPoint = new Domain.Point
            {
                X = e.GetPosition(DrawCanvas).X,
                Y = e.GetPosition(DrawCanvas).Y
            };

            int i = CurrentPentagon.Points.Count;
            if (i > 0)
            {
                Line line = new Line
                {
                    X1 = CurrentPentagon.Points[i - 1].X,
                    Y1 = CurrentPentagon.Points[i - 1].Y,
                    X2 = LastPoint.X,
                    Y2 = LastPoint.Y,
                    Stroke = new SolidColorBrush(Colors.Gray)
                };
                line.MouseUp += CanvasClick;
                DrawCanvas.Children.Add(line);
            }

            CurrentPentagon.AddPoint(LastPoint);

            if (CurrentPentagon.IsCompleted())
            {
                CurrentPentagon.Color = AskPentagonColor();
                DrawPentagon(CurrentPentagon);
                Canvas.AddPentagon(CurrentPentagon);
                CurrentPentagon = new Pentagon();
            }
        }

        private Domain.Color AskPentagonColor()
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return new Domain.Color
                {
                    R = dialog.Color.R,
                    G = dialog.Color.G,
                    B = dialog.Color.B
                };
            }
            else
            {
                Random random = new Random();
                return new Domain.Color
                {
                    R = (byte)random.Next(0, 255),
                    G = (byte)random.Next(0, 255),
                    B = (byte)random.Next(0, 255)
                };
            }
        }

        private void DrawPentagon(Pentagon pentagon)
        {
            Polygon polygon = ConvertPentagonToPolygon(pentagon);
            DrawCanvas.Children.Add(polygon);
        }

        private Polygon ConvertPentagonToPolygon(Pentagon pentagon)
        {
            Polygon polygon = new Polygon
            {
                StrokeThickness = 2,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush()
                {
                    Color = new System.Windows.Media.Color
                    {
                        R = pentagon.Color.R,
                        G = pentagon.Color.G,
                        B = pentagon.Color.B,
                        A = 255
                    }
                }
            };
            foreach (Domain.Point PentatonPoint in pentagon.Points)
            {
                polygon.Points.Add(new System.Windows.Point
                {
                    X = PentatonPoint.X,
                    Y = PentatonPoint.Y
                });
            }
            return polygon;
        }

        private void CanvasMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (CurrentPentagon.Points.Count != 0)
            {
                DrawCanvas.Children.Remove(FollowLine);
                FollowLine = new Line
                {
                    X1 = LastPoint.X,
                    Y1 = LastPoint.Y,
                    X2 = e.GetPosition(DrawCanvas).X,
                    Y2 = e.GetPosition(DrawCanvas).Y,
                    Stroke = new SolidColorBrush(Colors.Gray)
                };
                FollowLine.MouseUp += CanvasClick;
                DrawCanvas.Children.Add(FollowLine);
            }
        }
    }
}
