﻿using System.Windows;
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

        private Pentagon CurrentPentagon = new Pentagon();
        private Canvas Canvas = new Canvas();

        private List<Line> DrawLines = new List<Line>();
        private Domain.Point LastPoint;
        private Line FollowLine;

        private ObservableCollection<Polygon> Polygons = new ObservableCollection<Polygon>();

        private System.Windows.Point StartDrag;
        private Polygon DragPolygon;
        private bool IsDragging = false;

        private string CanvasFilePath;

        public MainWindow()
        {
            InitializeComponent();
            this.previewPolygones.ItemsSource = this.Polygons;
            ResetCanvas();
            Closing += new System.ComponentModel.CancelEventHandler((object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                if (Canvas.Pentagons.Count == 0)
                {
                    return;
                }

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
            if (DrawCanvas.Children.Count > 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Save changes?",
                    "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveAll();
                        ResetCanvas();
                        break;
                    case MessageBoxResult.No:
                        ResetCanvas();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
            {
                ResetCanvas();
            }
        }

        private void OpenSavedCanvas(object sender, RoutedEventArgs e)
        {
            if (DrawCanvas.Children.Count > 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Save changes?",
                    "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveAll();
                        OpenCanvas();
                        break;
                    case MessageBoxResult.No:
                        OpenCanvas();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
            {
                OpenCanvas();
            }
        }

        private void OpenCanvas()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.xml)|*.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ResetCanvas();
                SetCanvasFilePath(System.IO.Path.GetFullPath(dialog.FileName));
                Canvas = CanvasService.Get(CanvasFilePath);
                foreach (Pentagon pentagon in Canvas.Pentagons)
                {
                    DrawPentagon(pentagon);
                }
                UpdateShapesList();
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
            Polygons.Clear();
            UpdateShapesList();
        }

        private void SaveCanvas(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAll();
        }

        private void SaveCanvasAs(object sender, ExecutedRoutedEventArgs e)
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

        public void SaveAll()
        {
            if (Canvas.Pentagons.Count == 0)
            {
                System.Windows.MessageBox.Show("Nothing to save", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CanvasFilePath == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text file (*.xml)|*.xml";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SetCanvasFilePath(System.IO.Path.GetFullPath(dialog.FileName));
                }
                else
                {
                    return;
                }
            }
            CanvasService.Save(Canvas, CanvasFilePath);
        }

        private void CanvasClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsDragging)
            {
                return;
            }

            if (DragPolygon != null)
            {
                _PolygonStopDraggin();
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
            UpdateShapesList();
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
            Polygons.Add(polygon);
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
            if (IsDragging && DragPolygon != null)
            {
                double diffX = e.GetPosition(this.DrawCanvas).X - this.StartDrag.X;
                double diffY = e.GetPosition(this.DrawCanvas).Y - this.StartDrag.Y;
                for (int i = 0; i < DragPolygon.Points.Count; i++)
                {
                    System.Windows.Point point = DragPolygon.Points[i];
                    point.X += diffX;
                    point.Y += diffY;
                    DragPolygon.Points[i] = point;
                }
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
                FollowLine.MouseUp += CanvasClick;
                DrawCanvas.Children.Add(FollowLine);
            }

            CursorPositionLabel.Text = $"X: {e.GetPosition(DrawCanvas).X}; y: {e.GetPosition(DrawCanvas).Y}";
        }

        private void SelectPolygon(object sender, RoutedEventArgs e)
        {
            if (this.DragPolygon != null)
            {
                this.DragPolygon.Stroke = new SolidColorBrush(Colors.Black);
            }

            if (this.Polygons.Count == 0)
            {
                // just ignore if no polygones present
                return;
            }

            var item = (System.Windows.Controls.MenuItem)e.OriginalSource;
            this.DragPolygon = (Polygon)item.DataContext;
            this.DragPolygon.Stroke = new SolidColorBrush(Colors.Red);
            this.DragPolygon.MouseDown += new MouseButtonEventHandler(this.PolygonMouseDown);
            this.DragPolygon.MouseRightButtonDown += new MouseButtonEventHandler(this.PolygonStopDrag);
        }

        private void PolygonMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.IsDragging = true;
            this.StartDrag = e.GetPosition(this.DragPolygon);
        }

        private void PolygonStopDrag(object sender, MouseButtonEventArgs e)
        {
            _PolygonStopDraggin();
        }

        private void _PolygonStopDraggin()
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
            DragPolygon.MouseDown -= PolygonMouseDown;
            DragPolygon.MouseRightButtonDown -= PolygonStopDrag;
            DragPolygon = null;
            IsDragging = false;
        }

        private void UpdateShapesList()
        {
            previewPolygones.IsEnabled = Canvas.Pentagons.Count != 0;
        }

        private void SetCanvasFilePath(string filePath)
        {
            CanvasFilePath = filePath;
            this.Title = "Pentagon Drawer - " + filePath;
        }
    }
}
