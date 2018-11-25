using System.Windows;
using System.Windows.Shapes;
using Task2.Service;
using Task2.Domain;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Collections.Generic;

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
        private List<Line> DrawLines = new List<Line>();
        private ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();
        private Polygon dragPolygon = null;
        private bool dragging = false;
        private System.Windows.Point clickV;

        public MainWindow()
        {
            InitializeComponent();
            this.previewPolygones.ItemsSource = this.polygons;
            Closing += new System.ComponentModel.CancelEventHandler((object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Save changes?", "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveAll();
                        break;
                    case MessageBoxResult.No:
                        System.Windows.Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            });
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

        private void SaveCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAll();
        }

        public void SaveAll()
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
            if (dragging)
            {
                return;
            }

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
                DrawLines.Add(line);
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

        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
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
            polygons.Add(polygon);
            foreach(Line line in DrawLines)
            {
                DrawCanvas.Children.Remove(line);
            }
            DrawCanvas.Children.Remove(FollowLine);
            DrawLines.Clear();
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
            if (dragging && dragPolygon != null)
            {
                System.Windows.Controls.Canvas.SetLeft(this.dragPolygon, e.GetPosition(this.DrawCanvas).X - this.clickV.X);
                System.Windows.Controls.Canvas.SetTop(this.dragPolygon, e.GetPosition(this.DrawCanvas).Y - this.clickV.Y);
                return;
            }

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

            CursorPositionLabel.Text = $"X: {e.GetPosition(DrawCanvas).X}; y: {e.GetPosition(DrawCanvas).Y}";
        }

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            if (this.dragPolygon != null)
            {
                this.dragPolygon.Stroke = new SolidColorBrush(Colors.Black);
            }

            if (this.polygons.Count == 0)
            {
                // just ignore if no polygones present
                return;
            }

            var item = (System.Windows.Controls.MenuItem)e.OriginalSource;
            this.dragPolygon = (Polygon)item.DataContext;
            this.dragPolygon.Stroke = new SolidColorBrush(Colors.Red);
            this.dragPolygon.MouseDown += new MouseButtonEventHandler(this.PolygonMouseDown);
            this.dragPolygon.MouseRightButtonDown += new MouseButtonEventHandler(this.PolygonStopDrag);
        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragging = true;
            this.clickV = e.GetPosition(this.dragPolygon);
        }

        private void PolygonStopDrag(object sender, MouseButtonEventArgs e)
        {
            int index = polygons.IndexOf(dragPolygon);
            Pentagon pentagon = Canvas.Pentagons[index];
            pentagon.Points.Clear();
            foreach (System.Windows.Point PolygonPoint in dragPolygon.Points)
            {
                pentagon.AddPoint(new Domain.Point
                {
                    X = PolygonPoint.X,
                    Y = PolygonPoint.Y
                });
            }
            dragPolygon.Stroke = null;
            dragPolygon.MouseDown -= PolygonMouseDown;
            dragPolygon.MouseRightButtonDown -= PolygonStopDrag;
            dragPolygon = null;
            dragging = false;
        }

        
        //private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    System.Windows.MessageBox.Show("Save changes?", "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
        //    e.Cancel = true;
        //}
    }
}
