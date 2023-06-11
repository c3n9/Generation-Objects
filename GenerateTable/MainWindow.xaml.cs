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

namespace GenerateTable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListView listView = new ListView();
            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn { Header = "Id" , DisplayMemberBinding=new Binding("Id")});
            gridView.Columns.Add(new GridViewColumn { Header = "Номер заказа" , DisplayMemberBinding = new Binding("OrderNumber") });
            gridView.Columns.Add(new GridViewColumn { Header = "Дата заказа" , DisplayMemberBinding = new Binding("Date") });
            gridView.Columns.Add(new GridViewColumn { Header = "Продукт", DisplayMemberBinding = new Binding("Product.Name") });
            listView.View = gridView;
            MainGrid.Children.Add(listView);
            listView.ItemsSource = App.DB.Order.ToList();

        }
    }
}
