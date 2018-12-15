using System.Windows;
using System.Windows.Shapes;
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
        private Pentagon CurrentPentagon = new Pentagon();
        private Canvas Canvas = new Canvas();

        private List<Line> DrawLines = new List<Line>();
        private Domain.Point LastPoint;
        private Line FollowLine;

        private ObservableCollection<Polygon> Polygons = new ObservableCollection<Polygon>();

        private System.Windows.Point StartDrag;
        private Polygon DragPolygon;
        private bool IsDragging = false;

        private bool SavedChanges = true;


        public MainWindow()
        {
            InitializeComponent();
            previewPolygones.ItemsSource = Polygons;
            previewPolygones2.ItemsSource = Polygons;
            ResetCanvas();
        }

        private void NewCanvas(object sender, RoutedEventArgs e)
        {
            SaveCanvasWarning(ResetCanvas);
            SetCanvasFilePath(null);
            SavedChanges = true;
        }

        private void OpenSavedCanvas(object sender, RoutedEventArgs e)
        {
            SaveCanvasWarning(OpenCanvas);
            SavedChanges = true;
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            SaveCanvas();
            SavedChanges = true;
        }

        private void SaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            SaveCanvasAs();
            SavedChanges = true;
        }

        private void ResetCanvas()
        {
            ResetCanvas(null);
        }

        private void ResetCanvas(Canvas canvas)
        {
            if (canvas == null)
            {
                Canvas = new Canvas();
            }
            else
            {
                Canvas = canvas;
            }

            DrawCanvas.Children.Clear();
            DrawCanvas.Visibility = Visibility.Visible;
            CurrentPentagon = new Pentagon();
            LastPoint = null;
            FollowLine = null;
            Polygons.Clear();
            foreach (Pentagon pentagon in Canvas.Pentagons)
            {
                DrawPentagon(pentagon);
            }
            UpdateShapesList();
            SavedChanges = true;
        }

        private void CanvasClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            if (IsDragging)
            {
                return;
            }

            if (DragPolygon != null)
            {
                PolygonStopDraggin();
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
                DrawLines.Add(line);
                DrawCanvas.Children.Add(line);
            }           

            CurrentPentagon.AddPoint(LastPoint);
            
            if (CurrentPentagon.IsCompleted())
            {
                CurrentPentagon.Color = AskPentagonColor();
                if (CurrentPentagon.Color != null)
                {
                    DrawPentagon(CurrentPentagon);
                    Canvas.AddPentagon(CurrentPentagon);
                }
                ResetFollowLines();
            }
            UpdateShapesList();
        }

        private void CanvasRightClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            if (CurrentPentagon.Points.Count == 0)
            {
                previewPolygones2.IsOpen = true;
            }
            else
            {
                ResetFollowLines();
            }
        }

        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDragging = false;
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
                return null;
            }
        }

        private void DrawPentagon(Pentagon pentagon)
        {
            Polygon polygon = ConvertPentagonToPolygon(pentagon);
            DrawCanvas.Children.Add(polygon);
            Polygons.Add(polygon);
            SavedChanges = false;
        }

        private void ResetFollowLines()
        {
            foreach (Line line in DrawLines)
            {
                DrawCanvas.Children.Remove(line);
            }
            DrawCanvas.Children.Remove(FollowLine);
            DrawLines.Clear();
            CurrentPentagon = new Pentagon();
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
            if (IsDragging && DragPolygon != null)
            {
                double diffX = e.GetPosition(DrawCanvas).X - StartDrag.X;
                double diffY = e.GetPosition(DrawCanvas).Y - StartDrag.Y;
                MovePentagon(DragPolygon, diffX, diffY);
                StartDrag = e.GetPosition(DrawCanvas);
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
                FollowLine.MouseLeftButtonDown += CanvasClick;
                FollowLine.MouseRightButtonDown += CanvasRightClick;
                DrawCanvas.Children.Add(FollowLine);
            }

            CursorPositionLabel.Text = $"X: {e.GetPosition(DrawCanvas).X}; y: {e.GetPosition(DrawCanvas).Y}";
        }

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            if (DragPolygon != null)
            {
                DragPolygon.Stroke = new SolidColorBrush(Colors.Black);
            }

            if (Polygons.Count == 0)
            {
                // just ignore if no polygones present
                return;
            }

            var item = (System.Windows.Controls.MenuItem)e.OriginalSource;
            DragPolygon = (Polygon)item.DataContext;
            DragPolygon.Stroke = new SolidColorBrush(Colors.Red);
            DragPolygon.MouseLeftButtonDown += PolygonMouseDown;
        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {   
            IsDragging = true;
            StartDrag = e.GetPosition(DragPolygon);
        }

        private void PolygonStopDraggin()
        {
            int index = Polygons.IndexOf(DragPolygon);
            Pentagon pentagon = Canvas.Pentagons[index];
            pentagon.Points.Clear();
            foreach (System.Windows.Point PolygonPoint in DragPolygon.Points)
            {
                pentagon.AddPoint(new Domain.Point
                {
                    X = PolygonPoint.X,
                    Y = PolygonPoint.Y
                });
            }
            DragPolygon.Stroke = new SolidColorBrush(Colors.Black);
            DragPolygon.MouseLeftButtonDown -= PolygonMouseDown;
            DragPolygon = null;
            IsDragging = false;
        }

        private void UpdateShapesList()
        {
            previewPolygones.IsEnabled = Canvas.Pentagons.Count != 0;
            if (Canvas.Pentagons.Count != 0)
            {
                previewPolygones2.Visibility = Visibility.Visible;
            }
            else
            {
                previewPolygones2.Visibility = Visibility.Hidden;
            }
            previewPolygones2.IsOpen = false;
        }

        private void SaveCanvasWarning(Action action)
        {
            if (SavedChanges == true)
            {
                action();
                return;
            }

            if (DrawCanvas.Children.Count > 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Save changes?",
                    "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveCanvas();
                        action();
                        break;
                    case MessageBoxResult.No:
                        action();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
            {
                action();
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SavedChanges)
            {
                return;
            }

            if (Canvas.Pentagons.Count == 0)
            {
                return;
            }

            MessageBoxResult result = System.Windows.MessageBox.Show
            (
                "Save changes?", "Warning!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning
            );

            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveCanvas();
                    break;
                case MessageBoxResult.No:
                    System.Windows.Application.Current.Shutdown();
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void previewPolygones2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            previewPolygones2.IsOpen = false;
        }

        private void DrawCanvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (DragPolygon != null)
            {
                const double step = 20;
                double diffX = 0;
                double diffY = 0;

                if (e.Key == Key.Left)
                {
                    diffX = -step;
                }
                else if (e.Key == Key.Right)
                {
                    diffX = step;
                }
                else if (e.Key == Key.Up)
                {
                    diffY = -step;
                }
                else if (e.Key == Key.Down)
                {
                    diffY = step;
                }

                MovePentagon(DragPolygon, diffX, diffY);
            }
        }

        private void MovePentagon(Polygon polygon, double diffX, double diffY)
        {
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                System.Windows.Point point = polygon.Points[i];
                point.X += diffX;
                point.Y += diffY;
                DragPolygon.Points[i] = point;
            }
            SavedChanges = false;
        }
    }
}
