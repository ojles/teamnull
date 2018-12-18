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

        /// <summary>
        /// This function creates new, clear canvas
        /// </summary>
        private void NewCanvas(object sender, RoutedEventArgs e)
        {
            SaveCanvasWarning(ResetCanvas);
            SetCanvasFilePath(null);
            SavedChanges = true;
        }

        /// <summary>
        /// This function opens canvas that was saved earlier
        /// </summary>
        private void OpenSavedCanvas(object sender, RoutedEventArgs e)
        {
            SaveCanvasWarning(OpenCanvas);
            SavedChanges = true;
        }

        /// <summary>
        /// This function saves canvas to .xml file
        /// </summary>
        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            SaveCanvas();
            SavedChanges = true;
        }

        /// <summary>
        /// This function saves canvas where format can be chosen
        /// </summary>
        private void SaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            SaveCanvasAs();
            SavedChanges = true;
        }

        /// <summary>
        /// This function resets canvas
        /// </summary>
        private void ResetCanvas()
        {
            ResetCanvas(null);
        }

        /// <summary>
        /// This function resets canvas
        /// </summary>
        /// <param name="canvas">Canvas that is reset</param>
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

        /// <summary>
        /// This function is called when there is a mouse click on the canvas
        /// </summary>
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

        /// <summary>
        /// THis function is called when there is a right mouse click on the canvas
        /// </summary>
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

        /// <summary>
        /// This function is called when mouse click is released
        /// </summary>
        private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDragging = false;
        }

        /// <summary>
        /// This function asks about color of the drawn <see cref="Pentagon"/>
        /// </summary>
        /// <returns><see cref="Domain.Color"/></returns>
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

        /// <summary>
        /// This function draws <see cref="Pentagon"/> and adds it to <see cref="Polygon"/>
        /// </summary>
        /// <param name="pentagon"><see cref="Pentagon"/> that needs to be added</param>
        private void DrawPentagon(Pentagon pentagon)
        {
            Polygon polygon = ConvertPentagonToPolygon(pentagon);
            DrawCanvas.Children.Add(polygon);
            Polygons.Add(polygon);
            SavedChanges = false;
        }

        /// <summary>
        /// This function removes all previously drawn lines
        /// </summary>
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

        /// <summary>
        /// THis function converts <see cref="Pentagon"/> to <see cref="Polygon"/>
        /// </summary>
        /// <param name="pentagon"><see cref="Pentagon"/> that is coverted to <see cref="Polygon"/></param>
        /// <returns>Converted <see cref="Polygon"/> from <see cref="Pentagon"/></returns>
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

        /// <summary>
        /// This function is called when polygon is dragged by mouse
        /// </summary>
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

        /// <summary>
        /// This function selects <see cref="Polygon"/> from the existing ones
        /// </summary>
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

        /// <summary>
        /// This function i called when there is a mouse click on the <see cref="Polygon"/>
        /// </summary>
        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDragging = true;
            StartDrag = e.GetPosition(DragPolygon);
        }

        /// <summary>
        /// This function is called when <see cref="Polygon"/> is stopped dragging
        /// </summary>
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

        /// <summary>
        /// This function updates ShapesList
        /// </summary>
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

        /// <summary>
        /// This function displays and acts when unsaved <see cref="Canvas"/> is about to be closed
        /// </summary>
        /// <param name="action"></param>
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

        /// <summary>
        /// This function is called when <see cref="Window"/> is about to be closed
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        private void previewPolygones2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            previewPolygones2.IsOpen = false;
        }

        /// <summary>
        /// This function is called when key on keyboard is pressed when <see cref="Polygon"/> is selected
        /// </summary>
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

        /// <summary>
        /// This function moves <see cref="Polygon"/> on specified coordinates
        /// </summary>
        /// <param name="polygon"><see cref="Polygon"/> that is moved</param>
        /// <param name="diffX">Number of difference in coordinates on OX</param>
        /// <param name="diffY">Number of difference in coordinates on OY</param>
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
