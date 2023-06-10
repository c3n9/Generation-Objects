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

namespace DiagramGanta
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Grid diagram = new Grid();
        private Grid dateGrid = new Grid();
        private DatePicker startDate = new DatePicker();
        private DatePicker endDate = new DatePicker();
        public MainWindow()
        {
            InitializeComponent();
            InitializeElements();

            diagram.Children.Add(dateGrid);

        }
        private void InitializeElements()
        {
            RowDefinition row1 = new RowDefinition
            {
                Height = new GridLength(25)
            };
            RowDefinition row2 = new RowDefinition();
            diagram.RowDefinitions.Add(row1);
            diagram.RowDefinitions.Add(row2);
            StackPanel tools = new StackPanel();
            tools.Children.Add(startDate);
            tools.Children.Add(endDate);
            Button setRow = new Button
            {
                Width = 200,
                Content = "Add row"
            };
            setRow.Click += AddRow_Click;
            tools.Children.Add(setRow);
            tools.Orientation = Orientation.Horizontal;
            StackPanel date = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            for (int i = 1; i < 31; i++)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = i.ToString(),
                    Margin = new Thickness(0, 0, 20, 0)
                };
                date.Children.Add(textBlock);
            }
            GMainGrid.Children.Add(diagram);

            Grid.SetRow(tools, 0);
            diagram.Children.Add(tools);
            Grid.SetRow(date, 1);
            diagram.Children.Add(date);
            

        }
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            RowDefinition row = new RowDefinition();
            diagram.RowDefinitions.Add(row);
            Grid.SetRow(dateGrid, diagram.RowDefinitions.Count - 1);
            Random rnd = new Random();
            var error = String.Empty;
            if(startDate.SelectedDate == null)
                error += "Select start date\n";
            if (endDate.SelectedDate == null)
                error += "Select end date\n";
            if (!String.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            RowDefinition rowDates = new RowDefinition
            {
                Height = new GridLength(30)
            };
            dateGrid.RowDefinitions.Add(rowDates);
            for (int i = 1; i < 31; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                dateGrid.ColumnDefinitions.Add(column);
            }
            int difference = endDate.SelectedDate.Value.Day - startDate.SelectedDate.Value.Day;
            StackPanel rowPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Background = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)))
            };
            Grid.SetRow(rowPanel, 0);
            Grid.SetColumnSpan(rowPanel, difference+1);
            dateGrid.Children.Add(rowPanel);
        }
    }
}
