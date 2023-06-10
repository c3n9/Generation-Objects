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

namespace AlphabetButtons
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<char> alphabet = new List<char>();
        char currentLetter = ' ';
        public MainWindow()
        {
            InitializeComponent();
            GenerateButtons();
            Refresh();
        }
        private void Refresh()
        {
            var filter = App.DB.Player.ToList();
            if (currentLetter != ' ')
                filter = filter.Where(f => f.Name[0] == currentLetter).ToList();
            DGPlayers.ItemsSource = filter;
        }
        private void GenerateButtons()
        {
            for (int i = 0; i < 26; i++)
            {
                alphabet.Add(Convert.ToChar(i + 65));
            }
            foreach (char letter in alphabet)
            {
                Button button = new Button();
                button.Content = letter;
                button.DataContext = letter;
                button.Click += Letter_Click;       
                WPAlphabetButtons.Children.Add(button);

            }
        }
        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            currentLetter = (char)(sender as Button).DataContext;
            Refresh();
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {
            currentLetter = ' ';
            Refresh();
        }
    }
}
