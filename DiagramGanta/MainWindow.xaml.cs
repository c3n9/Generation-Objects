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
        private DatePicker startDate = new DatePicker();
        private DatePicker endDate = new DatePicker();
        private List<String> notions = new List<String>();
        private TextBox textBox = new TextBox
        {
            MaxLength = 20,
            Width = 200
        };
        public MainWindow()
        {
            InitializeComponent();
            InitializeElements();

        }
        private void InitializeElements()
        {
            RowDefinition row1 = new RowDefinition
            {
                Height = new GridLength(25)
            };
            RowDefinition row2 = new RowDefinition()
            {
                Height = new GridLength(25)
            };
            diagram.RowDefinitions.Add(row1);
            diagram.RowDefinitions.Add(row2);
            StackPanel tools = new StackPanel();
            tools.Children.Add(startDate);
            tools.Children.Add(endDate);
            tools.Children.Add(textBox);
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
                    Text = i.ToString()
                };
                ColumnDefinition column = new ColumnDefinition();
                diagram.ColumnDefinitions.Add(column);
                Grid.SetRow(textBlock, 1);
                Grid.SetColumn(textBlock, i);
                diagram.Children.Add(textBlock);
            }
            ColumnDefinition column2 = new ColumnDefinition()
            {
                Width = new GridLength(40)
            };
            diagram.ColumnDefinitions.Add(column2);
            GMainGrid.Children.Add(diagram);
            Grid.SetRow(tools, 0);
            Grid.SetColumnSpan(tools, 30);
            diagram.Children.Add(tools);
        }
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var error = String.Empty;
            if (startDate.SelectedDate == null)
                error += "Select start date\n";
            if (endDate.SelectedDate == null)
                error += "Select end date\n";
            if (String.IsNullOrWhiteSpace(textBox.Text))
                error += "Enter notion";
            if (!String.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            RowDefinition row = new RowDefinition()
            {
                Height = new GridLength(50)
            };
            diagram.RowDefinitions.Add(row);
            TextBlock textBlock = new TextBlock()
            {
                Text = textBox.Text,
                TextWrapping = TextWrapping.Wrap,
                Width = 30
            };
            int difference = endDate.SelectedDate.Value.Day - startDate.SelectedDate.Value.Day;
            StackPanel rowPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Background = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)))
            };
            int allRows = diagram.RowDefinitions.Count;
            Grid.SetRow(rowPanel, allRows-1);
            Grid.SetColumn(rowPanel, startDate.SelectedDate.Value.Day);
            Grid.SetColumnSpan(rowPanel, difference);
            diagram.Children.Add(rowPanel);
            Grid.SetRow(textBlock, allRows - 1);
            Grid.SetColumn(textBlock, 0);
            diagram.Children.Add(textBlock);
        }
    }
}
