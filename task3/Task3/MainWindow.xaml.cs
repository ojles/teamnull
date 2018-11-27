using System.Collections.Generic;
using System.Windows;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class Item
    {
        public string Name
        {
            get;
            set;
        }
        public int Qty
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public double Sum
        {
            get
            {
               return this.Qty * this.Price;
            }
            set
            {
                Sum = value;
            }
        }
        public string ImgPath
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, Qty, Price, Sum);
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Item i1 = new Item();
            i1.Name = "Coffee";
            i1.Price = 20;
            i1.Qty = 3;
            i1.ImgPath = "/Images/cafe.png";
            Item i2 = new Item();
            i2.Name = "Tea";
            i2.Price = 10;
            i2.Qty = 3;
            i2.ImgPath = "/Images/tea.png";
            List<Item> items = new List<Item>();
            items.Add(i1);
            items.Add(i2);
            //lvUsers.ItemsSource = items;
            Items.ItemsSource= items;
            
        }
    }
}
