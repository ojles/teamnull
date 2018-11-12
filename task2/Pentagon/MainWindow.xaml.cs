using System.Windows;
using System.Collections.Generic;
using System.Windows.Shapes;
using Task2.Service;
using Task2.Domain;
using System.Windows.Media;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CanvasService CanvasService = new CanvasService();
        private Canvas Canvas = new Canvas();
        private Pentagon Pentagon = new Pentagon();
        private Domain.Point LastPoint;
        private Line FollowLine;
        private ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();
        private Polygon selectedPolygon = null;
        private bool dragging = false;
        private System.Windows.Point clickV;

        public MainWindow()
        {
            InitializeComponent();
            this.polygonesList.ItemsSource = this.polygons;
        }

        private void NewCanvas(object sender, RoutedEventArgs e)
        {
            DrawCanvas.Visibility = Visibility.Visible;
            Canvas = new Canvas();
        }

        private void OpenSavedCanvas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string fullPath = System.IO.Path.GetFullPath(dialog.FileName);
                Canvas = CanvasService.Get(fullPath);
                DrawCanvas.Children.Clear();
                Background = Brushes.White;
                DrawCanvas.Visibility = Visibility.Visible;
                foreach (Pentagon pentagon in Canvas.Pentagons)
                {
                    DrawPentagon(pentagon);
                }
            }
        }

        private void SaveCanvas(object sender, RoutedEventArgs e)
        {
            if (Canvas.Pentagons.Count == 0)
            {
                System.Windows.MessageBox.Show("Nothing to save", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text file (*.xml)|*.xml"
            };
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string path = System.IO.Path.GetFullPath(dialog.FileName);
                CanvasService.Save(Canvas, path);
            }
        }

        private void CanvasClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LastPoint = new Domain.Point
            {
                X = e.GetPosition(DrawCanvas).X,
                Y = e.GetPosition(DrawCanvas).Y
            };

            int i = Pentagon.Points.Count;
            if (i > 0)
            {
                Line line = new Line
                {
                    X1 = Pentagon.Points[i - 1].X,
                    Y1 = Pentagon.Points[i - 1].Y,
                    X2 = LastPoint.X,
                    Y2 = LastPoint.Y,
                    Stroke = new SolidColorBrush(Colors.Gray)
                };
                line.MouseUp += CanvasClick;
                DrawCanvas.Children.Add(line);
            }

            Pentagon.AddPoint(LastPoint);

            if (Pentagon.IsCompleted())
            {
                Pentagon.Color = AskPentagonColor();
                DrawPentagon(Pentagon);
                Canvas.AddPentagon(Pentagon);
                Pentagon = new Pentagon();
            }
        }

        private Domain.Color AskPentagonColor()
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            return new Domain.Color
            {
                R = dialog.Color.R,
                G = dialog.Color.G,
                B = dialog.Color.B
            };
        }

        private void DrawPentagon(Pentagon pentagon)
        {
            Polygon polygon = ConvertPentagonToPolygon(pentagon);
            DrawCanvas.Children.Add(polygon);
            polygons.Add(polygon);
        }

        private Polygon ConvertPentagonToPolygon(Pentagon pentagon)
        {
            Polygon polygon = new Polygon();
            foreach (Domain.Point PentatonPoint in Pentagon.Points)
            {
                polygon.Points.Add(new System.Windows.Point
                {
                    X = PentatonPoint.X,
                    Y = PentatonPoint.Y
                });
            }
            System.Windows.Media.Color polygonColor = new System.Windows.Media.Color
            {
                R = pentagon.Color.R,
                G = pentagon.Color.G,
                B = pentagon.Color.B,
                A = 255
            };
            polygon.Fill = new SolidColorBrush(polygonColor);
            polygon.StrokeThickness = 2;
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            return polygon;
        }

        private void CanvasMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Pentagon.Points.Count != 0)
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

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            if (this.selectedPolygon != null)
            {
                this.selectedPolygon.Stroke = new SolidColorBrush(Colors.Black);
            }

            if (this.polygons.Count == 0)
            {
                throw new InvalidOperationException("There is no shapes in the canvas");
            }

            var item = (System.Windows.Controls.MenuItem)e.OriginalSource;
            this.selectedPolygon = (Polygon)item.DataContext;
            this.selectedPolygon.Stroke = new SolidColorBrush(Colors.Red);
            this.selectedPolygon.MouseDown += new MouseButtonEventHandler(this.PolygonMouseDown);
        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragging = true;
            this.clickV = e.GetPosition(this.selectedPolygon);
        }
    }
}
