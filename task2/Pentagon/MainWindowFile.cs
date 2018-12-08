using System.Windows;
using Task2.Service;
using Task2.Domain;
using System.Windows.Forms;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ApplicationName = "Pentagon Drawer";

        private readonly CanvasService CanvasService = new CanvasService();

        private string CanvasFilePath;

        private void OpenCanvas()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Text file (*.xml)|*.xml";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SetCanvasFilePath(System.IO.Path.GetFullPath(dialog.FileName));
                    Canvas canvas = CanvasService.Get(CanvasFilePath);
                    ResetCanvas(canvas);
                }
            }
            catch (ServiceException)
            {
                System.Windows.MessageBox.Show
                (
                    "Failed to read canvas from file", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Error
                );
            }
        }

        public void SaveCanvas()
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

        public void SaveCanvasAs()
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
                SetCanvasFilePath(System.IO.Path.GetFullPath(dialog.FileName));
                CanvasService.Save(Canvas, CanvasFilePath);
            }
        }

        private void SetCanvasFilePath(string filePath)
        {
            CanvasFilePath = filePath;
            if (filePath == null)
            {
                Title = ApplicationName;
            }
            else
            {
                Title = $"{ApplicationName} - {filePath}";
            }
        }
    }
}
